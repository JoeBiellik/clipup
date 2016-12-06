namespace ClipUp.Windows
{
    partial class Preferences
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.checkBoxOpenLink = new System.Windows.Forms.CheckBox();
            this.checkBoxCopyLink = new System.Windows.Forms.CheckBox();
            this.checkBoxShowNotification = new System.Windows.Forms.CheckBox();
            this.tabPageHotkeys = new System.Windows.Forms.TabPage();
            this.tabPageCapture = new System.Windows.Forms.TabPage();
            this.checkBoxCaptureWindowShadow = new System.Windows.Forms.CheckBox();
            this.checkBoxCaptureCursor = new System.Windows.Forms.CheckBox();
            this.tabPageProxy = new System.Windows.Forms.TabPage();
            this.checkBoxShowProgress = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageCapture.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(291, 201);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(372, 201);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageHotkeys);
            this.tabControl.Controls.Add(this.tabPageCapture);
            this.tabControl.Controls.Add(this.tabPageProxy);
            this.tabControl.Location = new System.Drawing.Point(5, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(450, 190);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.checkBoxShowProgress);
            this.tabPageGeneral.Controls.Add(this.checkBoxOpenLink);
            this.tabPageGeneral.Controls.Add(this.checkBoxCopyLink);
            this.tabPageGeneral.Controls.Add(this.checkBoxShowNotification);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(442, 164);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // checkBoxOpenLink
            // 
            this.checkBoxOpenLink.AutoSize = true;
            this.checkBoxOpenLink.Location = new System.Drawing.Point(12, 79);
            this.checkBoxOpenLink.Name = "checkBoxOpenLink";
            this.checkBoxOpenLink.Size = new System.Drawing.Size(181, 17);
            this.checkBoxOpenLink.TabIndex = 2;
            this.checkBoxOpenLink.Text = "&Open link in browser after upload";
            this.checkBoxOpenLink.UseVisualStyleBackColor = true;
            // 
            // checkBoxCopyLink
            // 
            this.checkBoxCopyLink.AutoSize = true;
            this.checkBoxCopyLink.Location = new System.Drawing.Point(12, 56);
            this.checkBoxCopyLink.Name = "checkBoxCopyLink";
            this.checkBoxCopyLink.Size = new System.Drawing.Size(186, 17);
            this.checkBoxCopyLink.TabIndex = 1;
            this.checkBoxCopyLink.Text = "&Copy link to clipboard after upload";
            this.checkBoxCopyLink.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowNotification
            // 
            this.checkBoxShowNotification.AutoSize = true;
            this.checkBoxShowNotification.Location = new System.Drawing.Point(12, 10);
            this.checkBoxShowNotification.Name = "checkBoxShowNotification";
            this.checkBoxShowNotification.Size = new System.Drawing.Size(157, 17);
            this.checkBoxShowNotification.TabIndex = 0;
            this.checkBoxShowNotification.Text = "Show &notification on upload";
            this.checkBoxShowNotification.UseVisualStyleBackColor = true;
            // 
            // tabPageHotkeys
            // 
            this.tabPageHotkeys.Location = new System.Drawing.Point(4, 22);
            this.tabPageHotkeys.Name = "tabPageHotkeys";
            this.tabPageHotkeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHotkeys.Size = new System.Drawing.Size(442, 164);
            this.tabPageHotkeys.TabIndex = 3;
            this.tabPageHotkeys.Text = "Hotkeys";
            this.tabPageHotkeys.UseVisualStyleBackColor = true;
            // 
            // tabPageCapture
            // 
            this.tabPageCapture.Controls.Add(this.checkBoxCaptureWindowShadow);
            this.tabPageCapture.Controls.Add(this.checkBoxCaptureCursor);
            this.tabPageCapture.Location = new System.Drawing.Point(4, 22);
            this.tabPageCapture.Name = "tabPageCapture";
            this.tabPageCapture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCapture.Size = new System.Drawing.Size(442, 164);
            this.tabPageCapture.TabIndex = 1;
            this.tabPageCapture.Text = "Capture";
            this.tabPageCapture.UseVisualStyleBackColor = true;
            // 
            // checkBoxCaptureWindowShadow
            // 
            this.checkBoxCaptureWindowShadow.AutoSize = true;
            this.checkBoxCaptureWindowShadow.Location = new System.Drawing.Point(12, 33);
            this.checkBoxCaptureWindowShadow.Name = "checkBoxCaptureWindowShadow";
            this.checkBoxCaptureWindowShadow.Size = new System.Drawing.Size(244, 17);
            this.checkBoxCaptureWindowShadow.TabIndex = 5;
            this.checkBoxCaptureWindowShadow.Text = "Capture &shadow when shooting single window";
            this.checkBoxCaptureWindowShadow.UseVisualStyleBackColor = true;
            // 
            // checkBoxCaptureCursor
            // 
            this.checkBoxCaptureCursor.AutoSize = true;
            this.checkBoxCaptureCursor.Location = new System.Drawing.Point(12, 10);
            this.checkBoxCaptureCursor.Name = "checkBoxCaptureCursor";
            this.checkBoxCaptureCursor.Size = new System.Drawing.Size(200, 17);
            this.checkBoxCaptureCursor.TabIndex = 4;
            this.checkBoxCaptureCursor.Text = "Capture &mouse cursor in screenshots";
            this.checkBoxCaptureCursor.UseVisualStyleBackColor = true;
            // 
            // tabPageProxy
            // 
            this.tabPageProxy.Location = new System.Drawing.Point(4, 22);
            this.tabPageProxy.Name = "tabPageProxy";
            this.tabPageProxy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProxy.Size = new System.Drawing.Size(442, 164);
            this.tabPageProxy.TabIndex = 2;
            this.tabPageProxy.Text = "Proxy";
            this.tabPageProxy.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowProgress
            // 
            this.checkBoxShowProgress.AutoSize = true;
            this.checkBoxShowProgress.Location = new System.Drawing.Point(12, 33);
            this.checkBoxShowProgress.Name = "checkBoxShowProgress";
            this.checkBoxShowProgress.Size = new System.Drawing.Size(201, 17);
            this.checkBoxShowProgress.TabIndex = 3;
            this.checkBoxShowProgress.Text = "Show image &upload progress window";
            this.checkBoxShowProgress.UseVisualStyleBackColor = true;
            // 
            // Preferences
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(459, 236);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preferences";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageCapture.ResumeLayout(false);
            this.tabPageCapture.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageCapture;
        private System.Windows.Forms.CheckBox checkBoxCopyLink;
        private System.Windows.Forms.CheckBox checkBoxShowNotification;
        private System.Windows.Forms.CheckBox checkBoxCaptureWindowShadow;
        private System.Windows.Forms.CheckBox checkBoxCaptureCursor;
        private System.Windows.Forms.TabPage tabPageProxy;
        private System.Windows.Forms.TabPage tabPageHotkeys;
        private System.Windows.Forms.CheckBox checkBoxOpenLink;
        private System.Windows.Forms.CheckBox checkBoxShowProgress;
    }
}
