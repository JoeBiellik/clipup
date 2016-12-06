using System;
using System.Windows.Forms;

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
            this.checkBoxShowNotification.Checked = Settings.Instance.ShowNotification;
            this.checkBoxShowProgress.Checked = Settings.Instance.ShowProgress;
            this.checkBoxCopyLink.Checked = Settings.Instance.CopyLink;
            this.checkBoxOpenLink.Checked = Settings.Instance.OpenLink;
            this.checkBoxCaptureCursor.Checked = Settings.Instance.CaptureCursor;
            this.checkBoxCaptureWindowShadow.Checked = Settings.Instance.CaptureWindowShadow;
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
    }
}
