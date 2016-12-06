using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ClipUp.Sdk.Interfaces;
using JoeBiellik.Logging;
using JoeBiellik.Utils;
using JoeBiellik.Utils.Hotkeys;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

namespace ClipUp.Windows
{
    internal static class Program
    {
        internal static readonly string Name = "ClipUp";
        internal static readonly HotkeyManager HotkeyManager = new HotkeyManager();
        internal static readonly Dictionary<string, IUploadProvider> Providers = new Dictionary<string, IUploadProvider>();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LogManager.Configuration = Logging.SetupLogger<TrayApplication>(true, false, true);

            var providersJson = JObject.Parse("{}");

            try
            {
                Settings.Save();

                providersJson = JObject.Parse(File.ReadAllText(Settings.Path));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            foreach (var provider in IO.GetFiles("Providers", "*.dll"))
            {
                try
                {
                    var type = LoadProviderType(provider);

                    var json = providersJson["ProviderSettings"][Path.GetFileName(provider)]?.ToString();

                    if (string.IsNullOrWhiteSpace(json)) json = "{}";

                    Providers.Add(Path.GetFileName(provider) ?? provider, JsonConvert.DeserializeObject(json, type) as IUploadProvider);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }

            Settings.Instance.ProviderSettings = Providers.Where(p => p.Value is IConfigurableProvider).ToDictionary(p => p.Key, p => p.Value);
            Settings.Save();

            try
            {
                SingleInstance.Run(new TrayApplication());
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private static IUploadProvider LoadProvider(string file, object[] ctor)
        {
            try
            {
                var assembly = Assembly.LoadFrom(file);

                foreach (var type in assembly.GetTypes().Where(type => type.GetInterface(typeof(IUploadProvider).Name) != null && !type.IsAbstract))
                {
                    return (IUploadProvider)Activator.CreateInstance(type, ctor);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return null;
        }

        private static Type LoadProviderType(string file)
        {
            try
            {
                var assembly = Assembly.LoadFrom(file);

                foreach (var type in assembly.GetTypes().Where(type => type.GetInterface(typeof(IUploadProvider).Name) != null && !type.IsAbstract))
                {
                    return type;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return null;
        }
    }
}
