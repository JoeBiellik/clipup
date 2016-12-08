using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ClipUp.Sdk.Interfaces;
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

                try
                {
                    var json = providersJson["Providers"]?[key]?["Settings"]?.ToString() ?? "{}";
                    var type = Assembly.LoadFrom(provider).GetTypes().First(t => t.GetInterface(typeof(IUploadProvider).Name) != null && !t.IsAbstract);

                    if (Settings.Instance.Providers.ContainsKey(key))
                    {
                        Settings.Instance.Providers[key].Provider = JsonConvert.DeserializeObject(json, type) as IUploadProvider;
                    }
                    else
                    {
                        Settings.Instance.Providers.Add(key, new UploadProviderSettings { Provider = JsonConvert.DeserializeObject(json, type) as IUploadProvider });
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }

            Settings.Save();
        }
    }
}
