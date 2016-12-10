using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ClipUp.Sdk;
using ClipUp.Sdk.Interfaces;
using ClipUp.Sdk.Providers;
using JoeBiellik.Utils;
using JoeBiellik.Utils.Hotkeys;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace ClipUp.Windows
{
    internal static class Program
    {
        internal static readonly string Name = "ClipUp";
        internal static readonly HotkeyManager HotkeyManager = new HotkeyManager();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SetupLogging();
            LoadProviders();

            try
            {
                using (var tray = new TrayApplication())
                {
                    SingleInstance.Run(tray);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private static void SetupLogging()
        {
            var fileLog = new FileTarget
            {
                FileName = $"${{basedir}}/{typeof(Program).Assembly.GetName().Name}.log",
                // ReSharper disable once StringLiteralTypo
                Layout = @"[${date:universalTime=true:format=yyyy-MM-ddTHH\:mm\:ssK}] ${level:uppercase=true}: ${message} ${exception:format=tostring}"
            };

            var config = new LoggingConfiguration();
            config.AddTarget("file", fileLog);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, fileLog));

            LogManager.Configuration = config;
        }

        private static void LoadProviders()
        {
            if (!Settings.FileExists) Settings.Save();

            var providersJson = JObject.Parse("{}");

            try
            {
                providersJson = JObject.Parse(File.ReadAllText(Settings.Path));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            foreach (var provider in IO.GetFiles("Providers", "*.dll"))
            {
                var key = Path.GetFileNameWithoutExtension(provider) ?? provider;

                LoadProvider(provider, key, providersJson["Providers"]?[key]?["Settings"]?.ToString() ?? "{}");
            }

            // TODO: Check enabled
            if (Settings.Instance.Providers.Count(p => p.Key == Settings.Instance.DefaultTextProvider && p.Value.Provider is ITextUploadProvider) < 1)
            {
                Settings.Instance.DefaultTextProvider = Settings.Instance.Providers.First(p => p.Value.Provider is ITextUploadProvider).Key;
            }

            if (Settings.Instance.Providers.Count(p => p.Key == Settings.Instance.DefaultImageProvider && p.Value.Provider is IImageUploadProvider) < 1)
            {
                Settings.Instance.DefaultImageProvider = Settings.Instance.Providers.First(p => p.Value.Provider is IImageUploadProvider).Key;
            }

            Settings.Save();
        }

        private static void LoadProvider(string path, string key, string json)
        {
            try
            {
                var asm = Assembly.LoadFrom(path);
                var sdkVersion = asm.GetCustomAttribute<SdkVersionAttribute>();

                if (sdkVersion == null) throw new ProviderSdkVersionException(path);
                if (sdkVersion.Target != UploadProvider.SDK_VERSION) throw new ProviderSdkVersionException(path, sdkVersion.Target);

                var type = asm.GetTypes().First(t => t.GetInterface(typeof(IUploadProvider).Name) != null && !t.IsAbstract);

                var provider = JsonConvert.DeserializeObject(json, type) as IUploadProvider;

                if (Settings.Instance.Providers.ContainsKey(key))
                {
                    Settings.Instance.Providers[key].Provider = provider;
                }
                else
                {
                    Settings.Instance.Providers.Add(key, new UploadProviderSettings
                    {
                        Provider = provider
                    });
                }
            }
            catch (ProviderSdkVersionException ex)
            {
                // TODO: Exception handling

                Logger.Error(ex);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}
