﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Windows
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

            this.linkLink.Text = this.provider.Link;

            //this.labelAuthor.Text = "Author: ";

            //this.linkAuthor.Text = "";

            this.labelDescription.Text = this.provider.Description;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
