using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClipUp.Windows.Forms
{
    public partial class ScreenshotOverlay : Form
    {
        public Image SelectedImage => this.selectionPictureBox.SelectedImage;

        public Rectangle SelectedArea
        {
            get { return this.selectionPictureBox.SelectedArea; }
            set { this.selectionPictureBox.SelectedArea = value; }
        }

        public ScreenshotOverlay()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.InitializeComponent();
        }

        private void ScreenshotOverlay_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.FromPoint(MousePosition).Bounds;
            //this.Bounds = Screen.PrimaryScreen.Bounds;

            this.selectionPictureBox.Image = ScreenCapture.CaptureBounds(this.Bounds);
            //this.selectionPictureBox.Image = ScreenCapture.CapturePrimaryScreen();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var param = base.CreateParams;
                param.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return param;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;

                this.Close();
            }

            if (keyData == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void selectionPictureBox_SelectedAreaChanged(object sender, EventArgs e)
        {

        }
    }
}
