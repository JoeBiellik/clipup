using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Windows
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            this.InitializeComponent();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("ClipUp.Windows.Resources.tray.ico"));

            // General
            this.checkBoxShowNotification.Checked = Settings.Instance.ShowNotification;
            this.checkBoxShowProgress.Checked = Settings.Instance.ShowProgress;
            this.checkBoxCopyLink.Checked = Settings.Instance.CopyLink;
            this.checkBoxOpenLink.Checked = Settings.Instance.OpenLink;

            // Capture
            this.checkBoxCaptureCursor.Checked = Settings.Instance.CaptureCursor;
            this.checkBoxCaptureWindowShadow.Checked = Settings.Instance.CaptureWindowShadow;

            // Providers
            foreach (var provider in Settings.Instance.Providers)
            {
                this.listViewProviders.Items.Add(new ListViewItem(new[] { provider.Value.Provider.Name, provider.Value.Provider.Version.ToString(), this.GetProviderType(provider.Value.Provider), provider.Value.Provider.Description })
                {
                    Tag = provider.Key,
                    ForeColor = provider.Value.Enabled ? Color.Black : Color.Gray
                });
            }

            this.listViewProviders.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listViewProviders.Columns[0].Width += 10;
            this.listViewProviders.Columns[3].Width = this.listViewProviders.ClientSize.Width - this.listViewProviders.Columns[0].Width - 60 - 60;
        }

        private void listViewProviders_DoubleClick(object sender, EventArgs e)
        {
            var provider = Settings.Instance.Providers.First(p => p.Key == this.listViewProviders.SelectedItems[0].Tag.ToString());

            if (provider.Value.Provider is IConfigurableProvider)
            {
                this.settingsToolStripMenuItem_Click(null, null);
            }
            else
            {
                this.aboutToolStripMenuItem_Click(null, null);
            }
        }

        private void contextMenuStripProvider_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mousePosition = this.listViewProviders.PointToClient(MousePosition);
            var hit = this.listViewProviders.HitTest(mousePosition);

            e.Cancel = hit.Item == null;

            if (e.Cancel) return;
            if (this.listViewProviders.SelectedItems.Count < 1) return;

            var provider = Settings.Instance.Providers.First(p => p.Key == this.listViewProviders.SelectedItems[0].Tag.ToString());

            var configurable = provider.Value.Provider is IConfigurableProvider;

            this.contextMenuStripProvider.Items[0].Visible = configurable;
            this.contextMenuStripProvider.Items[1].Visible = configurable;
            this.contextMenuStripProvider.Items[2].Font = new Font(this.contextMenuStripProvider.Items[2].Font.FontFamily, this.contextMenuStripProvider.Items[2].Font.Size, !configurable ? FontStyle.Bold : FontStyle.Regular);
            this.contextMenuStripProvider.Items[4].Text = provider.Value.Enabled ? "&Disable" : "&Enable";
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var provider = Settings.Instance.Providers.First(p => p.Key == this.listViewProviders.SelectedItems[0].Tag.ToString());

            using (var form = new ProviderPreferences(provider.Value.Provider.Clone() as IUploadProvider))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Settings.Instance.Providers[provider.Key].Provider = form.Provider;

                    Settings.Save();
                }
            }
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var provider = Settings.Instance.Providers.First(p => p.Key == this.listViewProviders.SelectedItems[0].Tag.ToString());

            var enabled = this.disableToolStripMenuItem.Text == "Enable";

            Settings.Instance.Providers[provider.Key].Enabled = enabled;
            this.listViewProviders.SelectedItems[0].ForeColor = enabled ? Color.Black : Color.Gray;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var provider = Settings.Instance.Providers.First(p => p.Key == this.listViewProviders.SelectedItems[0].Tag.ToString());

            using (var form = new ProviderAbout(provider.Value.Provider.Clone() as IUploadProvider))
            {
                form.ShowDialog();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Settings.Instance.ShowNotification = this.checkBoxShowNotification.Checked;
            Settings.Instance.ShowProgress = this.checkBoxShowProgress.Checked;
            Settings.Instance.CopyLink = this.checkBoxCopyLink.Checked;
            Settings.Instance.OpenLink = this.checkBoxOpenLink.Checked;
            Settings.Instance.CaptureCursor = this.checkBoxCaptureCursor.Checked;
            Settings.Instance.CaptureWindowShadow = this.checkBoxCaptureWindowShadow.Checked;

            Settings.Save();

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetProviderType(IUploadProvider provider)
        {
            if (provider is IImageUploadProvider) return "Image";
            if (provider is ITextUploadProvider) return "Text";
            return "Unknown";
        }
    }
}
