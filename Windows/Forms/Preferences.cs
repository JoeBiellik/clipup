using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ClipUp.Sdk.Interfaces;
using ClipUp.Sdk.Providers;
using ClipUp.Windows.Forms.Provider;

namespace ClipUp.Windows.Forms
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
            foreach (var provider in Settings.Instance.Providers.OrderBy(p => p.Key))
            {
                this.listViewProviders.Items.Add(new ListViewItem(new[] { provider.Value.Provider.Name, provider.Value.Provider.Version.ToString(), provider.Value.Type.ToString(), provider.Value.Provider.Description })
                {
                    Tag = provider.Key,
                    ForeColor = provider.Value.Enabled ? Color.Black : Color.Gray
                });
            }

            this.listViewProviders.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listViewProviders.Columns[0].Width += 10;
            this.listViewProviders.Columns[3].Width = this.listViewProviders.ClientSize.Width - this.listViewProviders.Columns[0].Width - 60 - 60;

            this.BuildProviderMenuDataSource();
        }

        private void listViewProviders_DoubleClick(object sender, EventArgs e)
        {
            if (this.GetSelectedProvider().Value.IsConfigurable)
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

            var provider = this.GetSelectedProvider();

            var configurable = provider.Value.IsConfigurable;

            this.contextMenuStripProvider.Items[0].Visible = configurable;
            this.contextMenuStripProvider.Items[1].Visible = configurable;
            this.contextMenuStripProvider.Items[2].Font = new Font(this.contextMenuStripProvider.Items[2].Font.FontFamily, this.contextMenuStripProvider.Items[2].Font.Size, !configurable ? FontStyle.Bold : FontStyle.Regular);
            this.contextMenuStripProvider.Items[4].Text = provider.Value.Enabled ? "&Disable" : "&Enable";
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var provider = this.GetSelectedProvider();

            using (var form = new Provider.Preferences(provider.Value.Provider.Clone() as IUploadProvider))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Settings.Instance.Providers[provider.Key].Provider = form.Provider;

                    Settings.Save();
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new About(this.GetSelectedProvider().Value)) form.ShowDialog();
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var enable = this.disableToolStripMenuItem.Text == "&Enable";

            if (!enable && this.GetSelectedProvider().Value.IsDefault)
            {
                MessageBox.Show($"You cannot disable a default provider!{Environment.NewLine}Change the default to another provider and try again.", Program.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            Settings.Instance.Providers[this.GetSelectedProvider().Key].Enabled = enable;
            this.listViewProviders.SelectedItems[0].ForeColor = enable ? Color.Black : Color.Gray;

            this.BuildProviderMenuDataSource();
        }

        private void comboBoxDefaultTextProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.DefaultTextProvider = ((dynamic)this.comboBoxDefaultTextProvider.SelectedItem).Key;
        }

        private void comboBoxDefaultImageProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.DefaultImageProvider = ((dynamic)this.comboBoxDefaultImageProvider.SelectedItem).Key;
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

        private KeyValuePair<string, UploadProviderSettings> GetSelectedProvider()
        {
            return Settings.Instance.Providers.First(p => p.Key == this.listViewProviders.SelectedItems[0].Tag.ToString());
        }
        private void BuildProviderMenuDataSource()
        {
            this.comboBoxDefaultTextProvider.SelectedIndexChanged -= this.comboBoxDefaultTextProvider_SelectedIndexChanged;
            this.comboBoxDefaultTextProvider.DataSource = Settings.Instance.Providers.Enabled.Where(p => p.Value.Type == UploadProviderTypes.Text).OrderBy(p => p.Key).Select(p => new
            {
                p.Key,
                p.Value.Provider.Name
            }).ToList();
            this.comboBoxDefaultTextProvider.SelectedValue = Settings.Instance.Providers.DefaultTextProvider.Key;
            this.comboBoxDefaultTextProvider.SelectedIndexChanged += this.comboBoxDefaultTextProvider_SelectedIndexChanged;

            this.comboBoxDefaultImageProvider.SelectedIndexChanged -= this.comboBoxDefaultImageProvider_SelectedIndexChanged;
            this.comboBoxDefaultImageProvider.DataSource = Settings.Instance.Providers.Enabled.Where(p => p.Value.Type == UploadProviderTypes.Image).OrderBy(p => p.Key).Select(p => new
            {
                p.Key,
                p.Value.Provider.Name
            }).ToList();
            this.comboBoxDefaultImageProvider.SelectedValue = Settings.Instance.Providers.DefaultImageProvider.Key;
            this.comboBoxDefaultImageProvider.SelectedIndexChanged += this.comboBoxDefaultImageProvider_SelectedIndexChanged;
        }
    }
}
