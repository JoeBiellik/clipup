using System;
using System.Windows.Forms;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Windows
{
    public partial class ProviderPreferences : Form
    {
        public IUploadProvider Provider { get; }

        public ProviderPreferences(IUploadProvider provider)
        {
            if (!(provider is IConfigurableProvider))
            {
                throw new ArgumentException("Provider must implement IConfigurableProvider", nameof(provider));
            }

            this.Provider = provider;

            this.InitializeComponent();
        }

        private void ProviderPreferences_Load(object sender, EventArgs e)
        {
            this.Text = this.Provider.Name + " Provider Preferences";

            (this.Provider as IConfigurableProvider)?.Configure(this.panel.Controls);
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
