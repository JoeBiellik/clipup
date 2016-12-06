using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ClipUp.Windows
{
    [DefaultProperty("Image")]
    [ToolboxItem(true)]
    public class SelectionPictureBox : Control
    {
        protected Point DragOrigin { get; set; }
        protected Point DragOriginOffset { get; set; }
        protected DragHandleAnchor ResizeAnchor { get; set; }

        private Point startMousePosition;
        private Rectangle selectedArea = Rectangle.Empty;


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSelecting { get; protected set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMoving { get; protected set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsResizing { get; protected set; }

        public Image Image { get; set; }

        public Rectangle SelectedArea
        {
            get { return this.selectedArea; }
            set
            {
                if (this.SelectedArea == value) return;

                this.selectedArea = value;

                this.SelectedAreaChanged?.Invoke(this, EventArgs.Empty);

                this.PositionDragHandles();

                this.Invalidate();
            }
        }
        
        [Browsable(false)]
        public Image SelectedImage
        {
            get
            {
                if (this.SelectedArea.IsEmpty) return null;

                var img = new Bitmap(this.SelectedArea.Width, this.SelectedArea.Height, PixelFormat.Format32bppPArgb);

                using (var g = Graphics.FromImage(img))
                {
                    //g.CompositingQuality = CompositingQuality.HighQuality;
                    //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //g.SmoothingMode = SmoothingMode.HighQuality;

                    g.DrawImage(this.Image, new Rectangle(0, 0, img.Width, img.Height), this.SelectedArea, GraphicsUnit.Pixel);
                }

                return img;
            }
        }

        public Color OverlayColor { get; set; } = Color.FromArgb(127, Color.Black);

        public int DragHandleSize { get; set; } = 8;

        [Browsable(false)]
        public DragHandleCollection DragHandles { get; } = new DragHandleCollection();

        /// <summary>
        ///   Occurs when the SelectionRegion property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler SelectedAreaChanged;


        [Category("Action")]
        public event EventHandler SelectionMoved;

        [Category("Action")]
        public event EventHandler SelectionMoving;

        [Category("Action")]
        public event EventHandler SelectionResized;

        [Category("Action")]
        public event EventHandler SelectionResizing;

        public SelectionPictureBox()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!this.IsSelecting && !this.IsMoving && !this.IsResizing && e.Button == MouseButtons.Left && !this.DragOrigin.IsEmpty)
            {
                var anchor = this.DragHandles.HitTest(this.DragOrigin);

                if (anchor == DragHandleAnchor.None)
                {
                    this.IsMoving = true;

                    this.SelectionMoving?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    this.ResizeAnchor = anchor;
                    this.IsResizing = true;

                    this.SelectionResizing?.Invoke(this, EventArgs.Empty);
                }
            }

            if (!this.IsSelecting && !this.IsMoving && !this.IsResizing && e.Button == MouseButtons.Left && this.DragOrigin.IsEmpty)
            {
                this.IsSelecting = true;

                this.SelectedArea = Rectangle.Empty;

                this.startMousePosition = e.Location;
            }

            if (this.IsSelecting)
            {
                int x;
                int y;
                int w;
                int h;

                if (e.X < this.startMousePosition.X)
                {
                    x = e.X;
                    w = this.startMousePosition.X - e.X;
                }
                else
                {
                    x = this.startMousePosition.X;
                    w = e.X - this.startMousePosition.X;
                }

                if (e.Y < this.startMousePosition.Y)
                {
                    y = e.Y;
                    h = this.startMousePosition.Y - e.Y;
                }
                else
                {
                    y = this.startMousePosition.Y;
                    h = e.Y - this.startMousePosition.Y;
                }

                this.SelectedArea = new Rectangle(x, y, w, h);
            }

            this.SetCursor(e.Location);

            this.ProcessSelectionMove(e.Location);
            this.ProcessSelectionResize(e.Location);

            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var imagePoint = e.Location;

            if (e.Button == MouseButtons.Left && (this.SelectedArea.Contains(imagePoint) || this.DragHandles.HitTest(e.Location) != DragHandleAnchor.None))
            {
                this.DragOrigin = e.Location;
                this.DragOriginOffset = new Point(imagePoint.X - this.SelectedArea.X, imagePoint.Y - this.SelectedArea.Y);
            }
            else
            {
                this.DragOriginOffset = Point.Empty;
                this.DragOrigin = Point.Empty;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.IsMoving) this.SelectionMoved?.Invoke(this, EventArgs.Empty);
            if (this.IsResizing) this.SelectionResized?.Invoke(this, EventArgs.Empty);

            this.IsSelecting = false;
            this.IsResizing = false;
            this.IsMoving = false;
            this.DragOrigin = Point.Empty;
            this.DragOriginOffset = Point.Empty;

            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Image == null) return;

            // Background
            e.Graphics.DrawImageUnscaled(this.Image, this.ClientRectangle);

            // Overlay
            e.Graphics.SetClip(this.SelectedArea, CombineMode.Exclude);
            e.Graphics.FillRectangle(new SolidBrush(this.OverlayColor), this.ClientRectangle);
            e.Graphics.ResetClip();

            if (this.SelectedArea.IsEmpty) return;

            // Selection border
            ControlPaint.DrawBorder(e.Graphics, this.SelectedArea, Color.Black, ButtonBorderStyle.Solid);

            using (var pen = new Pen(Color.White, 1)
            {
                DashCap = DashCap.Round,
                DashPattern = new float[] { 3, 3 }
            })
            {
                e.Graphics.DrawRectangle(pen, this.SelectedArea.X, this.SelectedArea.Y, this.SelectedArea.Width - 1, this.SelectedArea.Height - 1);
            }

            // Resize handles
            foreach (var handle in this.DragHandles)
            {
                e.Graphics.FillRectangle(Brushes.Black, handle.Bounds.Left + 1, handle.Bounds.Top + 1, handle.Bounds.Width - 2, handle.Bounds.Height - 2);
                e.Graphics.DrawRectangle(Pens.White, handle.Bounds.Left + 1, handle.Bounds.Top + 1, handle.Bounds.Width - 2, handle.Bounds.Height - 2);
            }
        }

        private void SetCursor(Point point)
        {
            if (this.IsSelecting)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                var handleAnchor = this.IsResizing ? this.ResizeAnchor : this.DragHandles.HitTest(point);

                if (handleAnchor != DragHandleAnchor.None)
                {
                    switch (handleAnchor)
                    {
                        case DragHandleAnchor.TopLeft:
                        case DragHandleAnchor.BottomRight:
                            this.Cursor = Cursors.SizeNWSE;
                            break;
                        case DragHandleAnchor.TopCenter:
                        case DragHandleAnchor.BottomCenter:
                            this.Cursor = Cursors.SizeNS;
                            break;
                        case DragHandleAnchor.TopRight:
                        case DragHandleAnchor.BottomLeft:
                            this.Cursor = Cursors.SizeNESW;
                            break;
                        case DragHandleAnchor.MiddleLeft:
                        case DragHandleAnchor.MiddleRight:
                            this.Cursor = Cursors.SizeWE;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (this.IsMoving || this.SelectedArea.Contains(point))
                {
                    this.Cursor = Cursors.SizeAll;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void ProcessSelectionMove(Point cursorPosition)
        {
            if (!this.IsMoving) return;

            var x = Math.Max(0, cursorPosition.X - this.DragOriginOffset.X);
            if (x + this.SelectedArea.Width >= this.ClientRectangle.Width)
            {
                x = this.ClientRectangle.Width - this.SelectedArea.Width;
            }

            var y = Math.Max(0, cursorPosition.Y - this.DragOriginOffset.Y);
            if (y + this.SelectedArea.Height >= this.ClientRectangle.Height)
            {
                y = this.ClientRectangle.Height - this.SelectedArea.Height;
            }

            this.SelectedArea = new Rectangle(x, y, this.SelectedArea.Width, this.SelectedArea.Height);
        }

        private void ProcessSelectionResize(Point cursorPosition)
        {
            if (!this.IsResizing) return;

            var resizingTopEdge = this.ResizeAnchor >= DragHandleAnchor.TopLeft && this.ResizeAnchor <= DragHandleAnchor.TopRight;
            var resizingBottomEdge = this.ResizeAnchor >= DragHandleAnchor.BottomLeft && this.ResizeAnchor <= DragHandleAnchor.BottomRight;
            var resizingLeftEdge = this.ResizeAnchor == DragHandleAnchor.TopLeft || this.ResizeAnchor == DragHandleAnchor.MiddleLeft || this.ResizeAnchor == DragHandleAnchor.BottomLeft;
            var resizingRightEdge = this.ResizeAnchor == DragHandleAnchor.TopRight || this.ResizeAnchor == DragHandleAnchor.MiddleRight || this.ResizeAnchor == DragHandleAnchor.BottomRight;

            var left = this.SelectedArea.Left;
            var top = this.SelectedArea.Top;
            var right = this.SelectedArea.Right;
            var bottom = this.SelectedArea.Bottom;

            if (resizingTopEdge)
            {
                top = cursorPosition.Y > 0 ? cursorPosition.Y : 0;
            }
            else if (resizingBottomEdge)
            {
                bottom = cursorPosition.Y < this.ClientRectangle.Height ? cursorPosition.Y : this.ClientRectangle.Height;
            }

            if (resizingLeftEdge)
            {
                left = cursorPosition.X > 0 ? cursorPosition.X : 0;
            }
            else if (resizingRightEdge)
            {
                right = cursorPosition.X < this.ClientRectangle.Width ? cursorPosition.X : this.ClientRectangle.Width;

            }

            this.SelectedArea = new Rectangle(left, top, right - left, bottom - top);
        }

        private void PositionDragHandles()
        {
            if (this.DragHandles.Count < 1 || this.DragHandleSize < 1) return;

            if (this.SelectedArea.IsEmpty)
            {
                foreach (var handle in this.DragHandles)
                {
                    handle.Bounds = Rectangle.Empty;
                }
            }
            else
            {
                var left = this.SelectedArea.Left + this.ClientRectangle.Left + this.Padding.Left;
                var top = this.SelectedArea.Top + this.ClientRectangle.Top + this.Padding.Top;
                var right = left + this.SelectedArea.Width;
                var bottom = top + this.SelectedArea.Height;
                var halfWidth = this.SelectedArea.Width / 2;
                var halfHeight = this.SelectedArea.Height / 2;
                var halfDragHandleSize = this.DragHandleSize / 2;

                this.DragHandles[DragHandleAnchor.TopLeft].Bounds = new Rectangle(left - this.DragHandleSize, top - this.DragHandleSize, this.DragHandleSize, this.DragHandleSize);
                this.DragHandles[DragHandleAnchor.TopCenter].Bounds = new Rectangle(left + halfWidth - halfDragHandleSize, top - this.DragHandleSize, this.DragHandleSize, this.DragHandleSize);
                this.DragHandles[DragHandleAnchor.TopRight].Bounds = new Rectangle(right, top - this.DragHandleSize, this.DragHandleSize, this.DragHandleSize);
                this.DragHandles[DragHandleAnchor.MiddleLeft].Bounds = new Rectangle(left - this.DragHandleSize, top + halfHeight - halfDragHandleSize, this.DragHandleSize, this.DragHandleSize);
                this.DragHandles[DragHandleAnchor.MiddleRight].Bounds = new Rectangle(right, top + halfHeight - halfDragHandleSize, this.DragHandleSize, this.DragHandleSize);
                this.DragHandles[DragHandleAnchor.BottomLeft].Bounds = new Rectangle(left - this.DragHandleSize, bottom, this.DragHandleSize, this.DragHandleSize);
                this.DragHandles[DragHandleAnchor.BottomCenter].Bounds = new Rectangle(left + halfWidth - halfDragHandleSize, bottom, this.DragHandleSize, this.DragHandleSize);
                this.DragHandles[DragHandleAnchor.BottomRight].Bounds = new Rectangle(right, bottom, this.DragHandleSize, this.DragHandleSize);
            }
        }
    }
}
