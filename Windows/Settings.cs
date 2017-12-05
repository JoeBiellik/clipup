using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Input;
using ClipUp.Sdk.Interfaces;
using ClipUp.Sdk.Providers;
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
        public string DefaultTextProvider { get; set; } = "PasteFyi";
        public string DefaultImageProvider { get; set; } = "PastePictures";
        public List<Hotkey> Hotkeys { get; set; } = new List<Hotkey>();
        public ProviderDictionary Providers { get; set; } = new ProviderDictionary();

        public override Settings Initialize()
        {
            return new Settings
            {
                Hotkeys = new List<Hotkey>
                {
                    new Hotkey(Key.PrintScreen, ModifierKeys.None, true, "PrintScreen"),
                    new Hotkey(Key.C, ModifierKeys.Control | ModifierKeys.Shift, true, "Clipboard")
                }
            };
        }
    }

    public class ProviderDictionary : Dictionary<string, UploadProviderSettings>
    {
        public IEnumerable<KeyValuePair<string, UploadProviderSettings>> Enabled => this.Where(p => p.Value.Enabled);

        public IEnumerable<KeyValuePair<string, UploadProviderSettings>> Text => this.Where(p => p.Value.Type == UploadProviderTypes.Text);

        public IEnumerable<KeyValuePair<string, UploadProviderSettings>> Image => this.Where(p => p.Value.Type == UploadProviderTypes.Image);

        public IEnumerable<KeyValuePair<string, UploadProviderSettings>> Configurable => this.Where(p => p.Value.IsConfigurable);

        public KeyValuePair<string, UploadProviderSettings> DefaultTextProvider => this.FirstOrDefault(p => p.Key == Settings.Instance.DefaultTextProvider);

        public KeyValuePair<string, UploadProviderSettings> DefaultImageProvider => this.FirstOrDefault(p => p.Key == Settings.Instance.DefaultImageProvider);
    }

    public class UploadProviderSettings
    {
        [DefaultValue(true)]
        public bool Enabled { get; set; } = true;

        [JsonIgnore]
        public UploadProviderTypes Type => this.Provider is ITextUploadProvider ? UploadProviderTypes.Text : UploadProviderTypes.Image;

        [JsonIgnore]
        public bool IsConfigurable => this.Provider is IConfigurableProvider;

        [JsonIgnore]
        public bool IsDefault => this == Settings.Instance.Providers.DefaultTextProvider.Value || this == Settings.Instance.Providers.DefaultImageProvider.Value;

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
        public override bool CanConvert(Type type) => true;

        public override object ReadJson(JsonReader reader, Type type, object existingValue, JsonSerializer serializer) => null;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
