﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipUp.Sdk;
using ClipUp.Sdk.Interfaces;
using ClipUp.Windows.Forms;
using JoeBiellik.Utils.Hotkeys;
using Timer = System.Windows.Forms.Timer;

namespace ClipUp.Windows
{
    internal class TrayApplication : ApplicationContext
    {
        private readonly IContainer components = new Container();
        private readonly ScreenshotOverlay overlay = new ScreenshotOverlay();
        private readonly NotifyIcon icon;
        private Preferences preferences = new Preferences();
        private readonly Timer iconClickTimer = new Timer();
        private bool isFirstClick = true;
        private bool isDoubleClick;
        private int milliseconds;
        private UploadResult lastResult;

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public TrayApplication()
        {
            this.iconClickTimer.Interval = 100;
            this.iconClickTimer.Tick += this.iconClickTimer_Tick;

            this.icon = new NotifyIcon(this.components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("ClipUp.Windows.Resources.tray.ico")),
                Text = Program.Name,
                Visible = true
            };

            this.icon.ContextMenuStrip.Opening += this.ContextMenuStrip_Opening;
            this.icon.MouseDown += this.icon_MouseDown;
            this.icon.BalloonTipClicked += this.icon_BalloonTipClicked;

            try
            {
                foreach (var hotkey in Settings.Instance.Hotkeys)
                {
                    Program.HotkeyManager.Register(hotkey);
                }
            }
            catch (Exception ex)
            {
                // ignored
            }

            Program.HotkeyManager.KeyPressed += this.HotkeyManager_KeyPressed;
        }

        private async void HotkeyManager_KeyPressed(object sender, HotkeyPressedEventArgs e)
        {
            if (this.overlay.Visible) return;

            if (e.Hotkey.Tag.ToString() == "PrintScreen")
            {
                //ScreenCapture.CaptureAllScreens().Save(@"CaptureAllScreens.png", ImageFormat.Png);
                //ScreenCapture.CapturePrimaryScreen().Save(@"CapturePrimaryScreen.png", ImageFormat.Png);
                //ScreenCapture.CaptureActiveWindow().Save(@"CaptureActiveWindow.png", ImageFormat.Png);
                //ScreenCapture.CaptureActiveWindow(true).Save(@"CaptureActiveWindow-shadow.png", ImageFormat.Png);

                if (this.overlay.ShowDialog() == DialogResult.OK)
                {
                    //this.overlay.SelectedImage?.Save(@"selected.png", ImageFormat.Png);

                    await this.UploadImage(Settings.Instance.Providers.Where(p => p.Value.Provider is IImageUploadProvider).Select(p => p.Value.Provider).Cast<IImageUploadProvider>().First(), this.overlay.SelectedImage);
                }
            }

            this.overlay.SelectedArea = Rectangle.Empty;
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = false;

            this.icon.ContextMenuStrip.Items.Clear();

            this.icon.ContextMenuStrip.Items.Add(new ToolStripLabel("Screenshot") { Enabled = false });
            this.icon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("Take Screenshot...", null, (s, a) => { this.HotkeyManager_KeyPressed(null, null); })
            {
                ShortcutKeyDisplayString = "PrtScn"
            });
            this.icon.ContextMenuStrip.Items.Add(new ToolStripSeparator());

            this.BuildProviderMenu(this.icon.ContextMenuStrip);

            this.icon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            this.icon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("&Preferences...", null, (o, args) => this.ShowPreferences()));
            this.icon.ContextMenuStrip.Items.Add(new ToolStripMenuItem("&Exit", null, (s, a) => { Application.Exit(); }));
        }

        private void icon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (this.isFirstClick)
            {
                this.isFirstClick = false;

                this.iconClickTimer.Start();
            }
            else
            {
                if (this.milliseconds < SystemInformation.DoubleClickTime)
                {
                    this.isDoubleClick = true;
                }
            }
        }

        private void iconClickTimer_Tick(object sender, EventArgs e)
        {
            this.milliseconds += 100;

            if (this.milliseconds >= SystemInformation.DoubleClickTime)
            {
                this.iconClickTimer.Stop();

                if (this.isDoubleClick)
                {
                    this.ShowPreferences();
                }
                else
                {
                    typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this.icon, null);
                }

                this.isFirstClick = true;
                this.isDoubleClick = false;
                this.milliseconds = 0;
            }
        }

        private void ShowPreferences()
        {
            if (Application.OpenForms[nameof(this.preferences)] == null)
            {
                if (this.preferences.IsDisposed) this.preferences = new Preferences();

                this.preferences.Show();
            }
            else
            {
                this.preferences.Focus();
            }
        }

        private void icon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (this.lastResult.Success) Process.Start(this.lastResult.Url);
        }

        private void BuildProviderMenu(ToolStrip menu)
        {
            if (Clipboard.ContainsText())
            {
                menu.Items.Add(new ToolStripLabel("Clipboard (Text)") { Enabled = false });

                foreach (var provider in Settings.Instance.Providers.Where(p => p.Value.Provider is ITextUploadProvider && p.Value.Enabled).OrderBy(p => p.Key))
                {
                    menu.Items.Add(new ToolStripMenuItem(provider.Value.Provider.Name, null, async (s, a) =>
                    {
                        await this.UploadText((ITextUploadProvider)provider.Value.Provider, Clipboard.GetText());
                    })
                    {
                        Image = provider.Value.Provider.Icon?.ToBitmap()
                    });
                }
            }
            else if (Clipboard.ContainsImage())
            {
                menu.Items.Add(new ToolStripLabel("Clipboard (Image)") { Enabled = false });

                foreach (var provider in Settings.Instance.Providers.Where(p => p.Value.Provider is IImageUploadProvider && p.Value.Enabled).OrderBy(p => p.Key))
                {
                    menu.Items.Add(new ToolStripMenuItem(provider.Value.Provider.Name, null, async (s, a) =>
                    {
                        await this.UploadImage((IImageUploadProvider)provider.Value.Provider, Clipboard.GetImage());
                    })
                    {
                        Image = provider.Value.Provider.Icon?.ToBitmap()
                    });
                }
            }
        }

        private async Task UploadText(ITextUploadProvider provider, string text)
        {
            try
            {
                this.ProcessUpload(await provider.UploadText(new TextUploadOptions
                {
                    UserAgent = Program.Name
                }, text));
            }
            catch (Exception ex)
            {
                this.icon.ShowBalloonTip(1500, Program.Name, $"There was an error with your upload: {ex.Message}", ToolTipIcon.Error);
            }
        }

        private async Task UploadImage(IImageUploadProvider provider, Image image)
        {
            try
            {
                var form = new UploadProgress();

                var progress = new Progress<int>(i =>
                {
                    form.Progress = i;
                });

                if (Settings.Instance.ShowProgress)
                {
                    form.Closing += (sender, e) =>
                    {
                        // TODO: Cancel upload
                    };

                    form.Show();
                }

                this.ProcessUpload(await provider.UploadImage(new ImageUploadOptions
                {
                    UserAgent = Program.Name,
                    Format = Settings.Instance.UploadFormat
                }, image, progress));

                form.Close();
            }
            catch (Exception ex)
            {
                this.icon.ShowBalloonTip(1500, Program.Name, $"There was an error with your upload: {ex.Message}", ToolTipIcon.Error);
            }
        }

        private void ProcessUpload(UploadResult result)
        {
            this.lastResult = result;

            if (Settings.Instance.CopyLink) Clipboard.SetText(result.Url);

            if (Settings.Instance.OpenLink) Process.Start(result.Url);

            if (Settings.Instance.ShowNotification) this.icon.ShowBalloonTip(500, Program.Name, result.Url, ToolTipIcon.Info);
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing) return;

            this.overlay?.Dispose();
            this.icon?.Dispose();
            this.components?.Dispose();
        }
    }
}
