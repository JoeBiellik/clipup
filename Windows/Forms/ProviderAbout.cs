using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Windows.Forms
{
    public partial class ProviderAbout : Form
    {
        private readonly IUploadProvider provider;

        public ProviderAbout(IUploadProvider provider)
        {
            this.provider = provider;

            this.InitializeComponent();
        }

        private void ProviderAbout_Load(object sender, EventArgs e)
        {
            this.Text = $"About {this.provider.Name}";

            this.labelTitle.Text = $"{this.provider.Name} version {this.provider.Version}";

            if (this.provider is IImageUploadProvider) this.labelAbout.Text = this.labelAbout.Text.Replace("text", "image");
            this.linkLink.Location = new Point(this.labelAbout.Location.X + this.labelAbout.Width - 6, this.linkLink.Location.Y);

            this.linkLink.Text = this.provider.Website;

            this.labelAuthor.Text = $"Author: {this.provider.AuthorName}";

            this.linkAuthor.Text = this.provider.AuthorWebsite;

            this.labelDescription.Text = this.provider.Description;
        }

        private void linkLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(this.provider.Website);
        }

        private void linkAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(this.provider.AuthorWebsite);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
