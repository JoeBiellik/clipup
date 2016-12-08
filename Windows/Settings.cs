using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Windows.Input;
using ClipUp.Sdk.Interfaces;
using JoeBiellik.Utils;
using JoeBiellik.Utils.Hotkeys;
using Newtonsoft.Json;

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
        public List<Hotkey> Hotkeys { get; set; } = new List<Hotkey>();
        public Dictionary<string, UploadProviderSettings> Providers { get; set; } = new Dictionary<string, UploadProviderSettings>();

        public override Settings Initialize()
        {
            return new Settings
            {
                Hotkeys = new List<Hotkey>
                {
                    new Hotkey(Key.PrintScreen, ModifierKeys.None, true, "PrintScreen")
                }
            };
        }
    }

    public class UploadProviderSettings
    {
        [DefaultValue(true)]
        public bool Enabled { get; set; } = true;

        [JsonProperty("Settings", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ProviderTypeConverter))]
        public IUploadProvider Provider { get; set; }

        public bool ShouldSerializeProvider()
        {
            return this.Provider is IConfigurableProvider;
        }
    }

    public class ProviderTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type type)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
        {
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
