using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipUp.Windows
{
    public static class ScreenCapture
    {
        private const int CURSOR_SHOWING = 0x0001;
        private const int DI_NORMAL = 0x0003;

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
        [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
        [Serializable, StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public static implicit operator Rectangle(Rect rect)
            {
                return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
        [StructLayout(LayoutKind.Sequential)]
        private struct CURSORINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
        [StructLayout(LayoutKind.Sequential)]
        // ReSharper disable once IdentifierTypo
        private struct POINTAPI
        {
            public int x;
            public int y;
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        // ReSharper disable once IdentifierTypo
        private enum DWMWINDOWATTRIBUTE : uint
        {
            ExtendedFrameBounds = 9
        }

        // ReSharper disable once StringLiteralTypo
        [DllImport("dwmapi.dll")]
        // ReSharper disable once IdentifierTypo
        private static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out Rect pvAttribute, int cbAttribute);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, out Rect rect);

        [DllImport("user32.dll")]
        private static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        // ReSharper disable once IdentifierTypo
        private static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);

        private static bool GetExtendedFrameBounds(IntPtr handle, out Rectangle rectangle)
        {
            Rect rect;

            var result = DwmGetWindowAttribute(handle, (int)DWMWINDOWATTRIBUTE.ExtendedFrameBounds, out rect, Marshal.SizeOf(typeof(Rect)));

            rectangle = rect;

            return result >= 0;
        }

        private static Rectangle GetWindowRectangle(IntPtr handle)
        {
            Rect rect;

            GetWindowRect(handle, out rect);

            return rect;
        }

        private static Rectangle GetExtendedWindowRectangle(IntPtr handle)
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                return GetWindowRectangle(handle);
            }

            Rectangle rectangle;

            return GetExtendedFrameBounds(handle, out rectangle) ? rectangle : GetWindowRectangle(handle);
        }

        public static Rectangle AllScreenBounds()
        {
            var screens = Screen.AllScreens.Select(s => s.Bounds).ToArray();

            return Rectangle.FromLTRB(screens.Min(b => b.Left), screens.Min(b => b.Top), screens.Max(b => b.Right), screens.Max(b => b.Bottom));
        }

        public static Image CaptureAllScreens(bool captureMouse = false)
        {
            return CaptureBounds(AllScreenBounds(), captureMouse);
        }

        public static Image CapturePrimaryScreen(bool captureMouse = false)
        {
            var bounds = Screen.PrimaryScreen.Bounds;

            return CaptureBounds(bounds, captureMouse);
        }

        public static Image CaptureActiveWindow(bool shadow = false, bool captureMouse = false)
        {
            var bounds = shadow ? GetWindowRectangle(GetForegroundWindow()) : GetExtendedWindowRectangle(GetForegroundWindow());

            return CaptureBounds(bounds, captureMouse);
        }

        public static Image CaptureBounds(Rectangle bounds, bool captureMouse = false)
        {
            var result = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppPArgb);

            try
            {
                using (var g = Graphics.FromImage(result))
                {
                    g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);

                    if (captureMouse)
                    {
                        CURSORINFO pci;
                        pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

                        if (GetCursorInfo(out pci))
                        {
                            if (pci.flags == CURSOR_SHOWING)
                            {
                                var hdc = g.GetHdc();
                                DrawIconEx(hdc, pci.ptScreenPos.x - bounds.X, pci.ptScreenPos.y - bounds.Y, pci.hCursor, 0, 0, 0, IntPtr.Zero, DI_NORMAL);
                                g.ReleaseHdc();
                            }
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }
    }
}
