namespace ClipUp.Windows.Forms.Provider
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelAbout = new System.Windows.Forms.Label();
            this.linkLink = new System.Windows.Forms.LinkLabel();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.linkAuthor = new System.Windows.Forms.LinkLabel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // buttonClose
            //
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(223, 126);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            //
            // labelTitle
            //
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(148, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Example version 1.0.0.0";
            //
            // labelAbout
            //
            this.labelAbout.AutoSize = true;
            this.labelAbout.Location = new System.Drawing.Point(12, 34);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(123, 13);
            this.labelAbout.TabIndex = 1;
            this.labelAbout.Text = "Provides text uploads to ";
            //
            // linkLink
            //
            this.linkLink.AutoSize = true;
            this.linkLink.Location = new System.Drawing.Point(129, 34);
            this.linkLink.Name = "linkLink";
            this.linkLink.Size = new System.Drawing.Size(97, 13);
            this.linkLink.TabIndex = 2;
            this.linkLink.TabStop = true;
            this.linkLink.Text = "http://website.com";
            this.linkLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLink_LinkClicked);
            //
            // labelAuthor
            //
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(12, 58);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(91, 13);
            this.labelAuthor.TabIndex = 3;
            this.labelAuthor.Text = "Author: Joe Biellik";
            //
            // linkAuthor
            //
            this.linkAuthor.AutoSize = true;
            this.linkAuthor.Location = new System.Drawing.Point(12, 82);
            this.linkAuthor.Name = "linkAuthor";
            this.linkAuthor.Size = new System.Drawing.Size(177, 13);
            this.linkAuthor.TabIndex = 4;
            this.linkAuthor.TabStop = true;
            this.linkAuthor.Text = "https://github.com/JoeBiellik/clipup";
            this.linkAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAuthor_LinkClicked);
            //
            // labelDescription
            //
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 106);
            this.labelDescription.MaximumSize = new System.Drawing.Size(300, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.labelDescription.Size = new System.Drawing.Size(262, 23);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            //
            // About
            //
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(310, 161);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.linkAuthor);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.linkLink);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Provider";
            this.Load += new System.EventHandler(this.About_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.LinkLabel linkLink;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.LinkLabel linkAuthor;
        private System.Windows.Forms.Label labelDescription;
    }
}
