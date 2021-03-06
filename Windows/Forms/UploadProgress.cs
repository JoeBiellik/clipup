﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClipUp.Windows.Forms
{
    public partial class UploadProgress : Form
    {
        protected override bool ShowWithoutActivation => true;

        public int Progress
        {
            get { return this.progressBar.Value; }
            set { this.progressBar.Value = value; }
        }

        public UploadProgress()
        {
            this.InitializeComponent();
        }

        private void UploadProgress_Load(object sender, EventArgs e)
        {
            var screenBounds = Screen.PrimaryScreen.WorkingArea;

            this.Location = new Point(screenBounds.Left + screenBounds.Width - this.Width, screenBounds.Top + screenBounds.Height - this.Height);
        }
    }
}
