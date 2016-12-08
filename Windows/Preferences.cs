using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            // General
            this.checkBoxShowNotification.Checked = Settings.Instance.ShowNotification;
            this.checkBoxShowProgress.Checked = Settings.Instance.ShowProgress;
            this.checkBoxCopyLink.Checked = Settings.Instance.CopyLink;
            this.checkBoxOpenLink.Checked = Settings.Instance.OpenLink;

            // Capture
            this.checkBoxCaptureCursor.Checked = Settings.Instance.CaptureCursor;
            this.checkBoxCaptureWindowShadow.Checked = Settings.Instance.CaptureWindowShadow;

            // Providers
            foreach (var provider in Program.Providers)
            {
                this.listViewProviders.Items.Add(new ListViewItem(new[] { provider.Value.Name, provider.Value.Version.ToString(), this.GetProviderType(provider.Value), provider.Value.Description })
                {
                    Tag = provider.Key
                });
            }

            this.listViewProviders.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listViewProviders.Columns[0].Width += 10;
            this.listViewProviders.Columns[3].Width = this.listViewProviders.ClientSize.Width - this.listViewProviders.Columns[0].Width - 60 - 60;
        }

        private void listViewProviders_DoubleClick(object sender, EventArgs e)
        {
            var provider = Program.Providers.First(p => p.Key == this.listViewProviders.SelectedItems[0].Tag.ToString());

            if (provider.Value is IConfigurableProvider)
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

            var provider = Program.Providers.First(p => p.Key == this.listViewProviders.SelectedItems[0].Tag.ToString());

            var configurable = provider.Value is IConfigurableProvider;

            this.contextMenuStripProvider.Items[0].Visible = configurable;
            this.contextMenuStripProvider.Items[1].Visible = configurable;
            this.contextMenuStripProvider.Items[2].Font = new Font(this.contextMenuStripProvider.Items[2].Font.FontFamily, this.contextMenuStripProvider.Items[2].Font.Size, !configurable ? FontStyle.Bold : FontStyle.Regular);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var provider = Program.Providers.First(p => p.Key == this.listViewProviders.SelectedItems[0].Tag.ToString());

            using (var form = new ProviderPreferences(provider.Value.Clone() as IUploadProvider))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Program.Providers[provider.Key] = form.Provider;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var provider = Program.Providers.First(p => p.Key == this.listViewProviders.SelectedItems[0].Tag.ToString());

            using (var form = new ProviderAbout(provider.Value.Clone() as IUploadProvider))
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
