using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ClipUp.Sdk.Providers;

namespace ClipUp.Windows.Forms.Provider
{
    public partial class About : Form
    {
        private readonly UploadProviderSettings provider;

        public About(UploadProviderSettings provider)
        {
            this.provider = provider;

            this.InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.Text = $"About {this.provider.Provider.Name}";

            this.labelTitle.Text = $"{this.provider.Provider.Name} version {this.provider.Provider.Version}";

            if (this.provider.Type == UploadProviderTypes.Image) this.labelAbout.Text = this.labelAbout.Text.Replace("text", "image");
            this.linkLink.Location = new Point(this.labelAbout.Location.X + this.labelAbout.Width - 6, this.linkLink.Location.Y);

            this.linkLink.Text = this.provider.Provider.Website;

            this.labelAuthor.Text = $"Author: {this.provider.Provider.AuthorName}";

            this.linkAuthor.Text = this.provider.Provider.AuthorWebsite;

            this.labelDescription.Text = this.provider.Provider.Description;
        }

        private void linkLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(this.provider.Provider.Website);
        }

        private void linkAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(this.provider.Provider.AuthorWebsite);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
