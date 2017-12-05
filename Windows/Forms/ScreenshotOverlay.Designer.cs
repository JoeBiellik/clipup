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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenshotOverlay));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.moveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.penToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.textToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uploadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.selectionPictureBox = new ClipUp.Windows.Controls.SelectionPictureBox();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripButton,
            this.penToolStripButton,
            this.textToolStripButton,
            this.toolStripSeparator,
            this.uploadToolStripButton,
            this.copyToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.cancelToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(29, 87);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(3, 2, 2, 1);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(211, 26);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";
            // 
            // moveToolStripButton
            // 
            this.moveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("moveToolStripButton.Image")));
            this.moveToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.moveToolStripButton.Name = "moveToolStripButton";
            this.moveToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.moveToolStripButton.Text = "&Move";
            // 
            // penToolStripButton
            // 
            this.penToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.penToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("penToolStripButton.Image")));
            this.penToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.penToolStripButton.Name = "penToolStripButton";
            this.penToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.penToolStripButton.Text = "&Pen";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.saveToolStripButton.Text = "&Save";
            // 
            // textToolStripButton
            // 
            this.textToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.textToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("textToolStripButton.Image")));
            this.textToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.textToolStripButton.Name = "textToolStripButton";
            this.textToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.textToolStripButton.Text = "&Text";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 23);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // uploadToolStripButton
            // 
            this.uploadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uploadToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("uploadToolStripButton.Image")));
            this.uploadToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.uploadToolStripButton.Name = "uploadToolStripButton";
            this.uploadToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.uploadToolStripButton.Text = "&Upload";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // cancelToolStripButton
            // 
            this.cancelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cancelToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelToolStripButton.Image")));
            this.cancelToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.cancelToolStripButton.Name = "cancelToolStripButton";
            this.cancelToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.cancelToolStripButton.Text = "C&ancel";
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
            this.selectionPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectionPictureBox_MouseClick);
            // 
            // ScreenshotOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.toolStrip);
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
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectionPictureBox selectionPictureBox;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton moveToolStripButton;
        private System.Windows.Forms.ToolStripButton penToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton textToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton uploadToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cancelToolStripButton;
    }
}
