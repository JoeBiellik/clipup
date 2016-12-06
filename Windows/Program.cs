using System;
using System.Collections.Generic;
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
        internal static readonly Dictionary<string, IUploadProvider> Providers = new Dictionary<string, IUploadProvider>();
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
                SingleInstance.Run(new TrayApplication());
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
