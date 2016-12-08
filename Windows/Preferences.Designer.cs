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
            this.components = new System.ComponentModel.Container();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.checkBoxShowProgress = new System.Windows.Forms.CheckBox();
            this.checkBoxOpenLink = new System.Windows.Forms.CheckBox();
            this.checkBoxCopyLink = new System.Windows.Forms.CheckBox();
            this.checkBoxShowNotification = new System.Windows.Forms.CheckBox();
            this.tabPageProviders = new System.Windows.Forms.TabPage();
            this.listViewProviders = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripProvider = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageHotkeys = new System.Windows.Forms.TabPage();
            this.tabPageCapture = new System.Windows.Forms.TabPage();
            this.checkBoxCaptureWindowShadow = new System.Windows.Forms.CheckBox();
            this.checkBoxCaptureCursor = new System.Windows.Forms.CheckBox();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageProviders.SuspendLayout();
            this.contextMenuStripProvider.SuspendLayout();
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
            this.tabControl.Controls.Add(this.tabPageProviders);
            this.tabControl.Controls.Add(this.tabPageHotkeys);
            this.tabControl.Controls.Add(this.tabPageCapture);
            this.tabControl.Controls.Add(this.tabPageAbout);
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
            // checkBoxShowProgress
            // 
            this.checkBoxShowProgress.AutoSize = true;
            this.checkBoxShowProgress.Location = new System.Drawing.Point(12, 33);
            this.checkBoxShowProgress.Name = "checkBoxShowProgress";
            this.checkBoxShowProgress.Size = new System.Drawing.Size(201, 17);
            this.checkBoxShowProgress.TabIndex = 1;
            this.checkBoxShowProgress.Text = "Show image &upload progress window";
            this.checkBoxShowProgress.UseVisualStyleBackColor = true;
            // 
            // checkBoxOpenLink
            // 
            this.checkBoxOpenLink.AutoSize = true;
            this.checkBoxOpenLink.Location = new System.Drawing.Point(12, 79);
            this.checkBoxOpenLink.Name = "checkBoxOpenLink";
            this.checkBoxOpenLink.Size = new System.Drawing.Size(181, 17);
            this.checkBoxOpenLink.TabIndex = 3;
            this.checkBoxOpenLink.Text = "&Open link in browser after upload";
            this.checkBoxOpenLink.UseVisualStyleBackColor = true;
            // 
            // checkBoxCopyLink
            // 
            this.checkBoxCopyLink.AutoSize = true;
            this.checkBoxCopyLink.Location = new System.Drawing.Point(12, 56);
            this.checkBoxCopyLink.Name = "checkBoxCopyLink";
            this.checkBoxCopyLink.Size = new System.Drawing.Size(186, 17);
            this.checkBoxCopyLink.TabIndex = 2;
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
            // tabPageProviders
            // 
            this.tabPageProviders.Controls.Add(this.listViewProviders);
            this.tabPageProviders.Location = new System.Drawing.Point(4, 22);
            this.tabPageProviders.Name = "tabPageProviders";
            this.tabPageProviders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProviders.Size = new System.Drawing.Size(442, 164);
            this.tabPageProviders.TabIndex = 2;
            this.tabPageProviders.Text = "Providers";
            this.tabPageProviders.UseVisualStyleBackColor = true;
            // 
            // listViewProviders
            // 
            this.listViewProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProviders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderVersion,
            this.columnHeaderType,
            this.columnHeaderDescription});
            this.listViewProviders.ContextMenuStrip = this.contextMenuStripProvider;
            this.listViewProviders.FullRowSelect = true;
            this.listViewProviders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewProviders.Location = new System.Drawing.Point(6, 6);
            this.listViewProviders.Name = "listViewProviders";
            this.listViewProviders.ShowGroups = false;
            this.listViewProviders.Size = new System.Drawing.Size(430, 152);
            this.listViewProviders.TabIndex = 0;
            this.listViewProviders.UseCompatibleStateImageBehavior = false;
            this.listViewProviders.View = System.Windows.Forms.View.Details;
            this.listViewProviders.DoubleClick += new System.EventHandler(this.listViewProviders_DoubleClick);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 150;
            // 
            // columnHeaderVersion
            // 
            this.columnHeaderVersion.Text = "Version";
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.Width = 134;
            // 
            // contextMenuStripProvider
            // 
            this.contextMenuStripProvider.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator2,
            this.disableToolStripMenuItem});
            this.contextMenuStripProvider.Name = "contextMenuStripProvider";
            this.contextMenuStripProvider.Size = new System.Drawing.Size(153, 104);
            this.contextMenuStripProvider.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripProvider_Opening);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "&Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            // tabPageAbout
            // 
            this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(442, 164);
            this.tabPageAbout.TabIndex = 4;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.disableToolStripMenuItem.Text = "&Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageProviders.ResumeLayout(false);
            this.contextMenuStripProvider.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPageProviders;
        private System.Windows.Forms.TabPage tabPageHotkeys;
        private System.Windows.Forms.CheckBox checkBoxOpenLink;
        private System.Windows.Forms.CheckBox checkBoxShowProgress;
        private System.Windows.Forms.ListView listViewProviders;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderVersion;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProvider;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
    }
}
