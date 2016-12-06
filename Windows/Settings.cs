using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Input;
using ClipUp.Sdk.Interfaces;
using JoeBiellik.Utils;
using JoeBiellik.Utils.Hotkeys;

namespace ClipUp.Windows
{
    public class Settings : JsonSettings<Settings>
    {
        public bool ShowNotification { get; set; } = true;
        public bool ShowProgress { get; set; } = true;
        public bool CopyLink { get; set; } = true;
        public bool OpenLink { get; set; } = true;
        public bool CaptureCursor { get; set; } = false;
        public bool CaptureWindowShadow { get; set; } = false;
        public ImageFormat UploadFormat { get; set; } = ImageFormat.Png;
        public int UploadQuality { get; set; } = 90;
        public Dictionary<string, IUploadProvider> ProviderSettings { get; set; } = new Dictionary<string, IUploadProvider>();
        public List<Hotkey> Hotkeys { get; set; } = new List<Hotkey>
        {
            new Hotkey(Key.PrintScreen, ModifierKeys.None, true, "PrintScreen")
        };
    }
}
