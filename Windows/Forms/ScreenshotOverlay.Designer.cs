using ClipUp.Windows.Controls;

namespace ClipUp.Windows.Forms
{
    partial class ScreenshotOverlay
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
            this.selectionPictureBox = new SelectionPictureBox();
            this.SuspendLayout();
            //
            // selectionPictureBox
            //
            this.selectionPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionPictureBox.DragHandleSize = 8;
            this.selectionPictureBox.Image = null;
            this.selectionPictureBox.Location = new System.Drawing.Point(0, 0);
            this.selectionPictureBox.Name = "selectionPictureBox";
            this.selectionPictureBox.OverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.selectionPictureBox.SelectedArea = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.selectionPictureBox.Size = new System.Drawing.Size(284, 261);
            this.selectionPictureBox.TabIndex = 0;
            this.selectionPictureBox.Text = "selectionPictureBox1";
            this.selectionPictureBox.SelectedAreaChanged += new System.EventHandler(this.selectionPictureBox_SelectedAreaChanged);
            //
            // ScreenshotOverlay
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.selectionPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenshotOverlay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ScreenshotOverlay";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ScreenshotOverlay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SelectionPictureBox selectionPictureBox;
    }
}
