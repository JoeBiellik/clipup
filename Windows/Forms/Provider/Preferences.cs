using System;
using System.Windows.Forms;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Windows.Forms.Provider
{
    public partial class Preferences : Form
    {
        public IUploadProvider Provider { get; }

        public Preferences(IUploadProvider provider)
        {
            if (!(provider is IConfigurableProvider))
            {
                throw new ArgumentException("Provider must implement IConfigurableProvider", nameof(provider));
            }

            this.Provider = provider;

            this.InitializeComponent();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            this.Text = this.Provider.Name + " Provider Preferences";

            try
            {
                (this.Provider as IConfigurableProvider)?.Configure(this.panel.Controls);
            }
            catch (Exception)
            {
                // TODO: Handle

                throw;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
