using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipUp.Sdk;
using ClipUp.Sdk.Interfaces;
using ClipUp.Sdk.Providers;

namespace ClipUp.Providers.Pastebin
{
    public class Pastebin : TextUploadProvider, IConfigurableProvider
    {
        private const string UPLOAD_URL = "http://pastebin.com/api/api_post.php";
        private const string KEY = "64269a656668650a05cf01becfb9d05c";

        private readonly BindingList<KeyValuePair<string, string>> expiries = new BindingList<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("10M", "10 Minutes"),
            new KeyValuePair<string, string>("1H", "1 Hour"),
            new KeyValuePair<string, string>("1D", "1 Day"),
            new KeyValuePair<string, string>("1W", "1 Week"),
            new KeyValuePair<string, string>("2W", "2 Weeks"),
            new KeyValuePair<string, string>("1M", "1 Month"),
            new KeyValuePair<string, string>("N", "Never")
        };

        private readonly BindingList<KeyValuePair<string, string>> visibility = new BindingList<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("0", "Public"),
            new KeyValuePair<string, string>("1", "Unlisted")
        };

        public override string Name => "Pastebin.com";
        public override Version Version => new Version(1, 0, 0);
        public override string Website => "http://pastebin.com/";
        public override string Description => "Pastebin.com text upload";
        public override Icon Icon => this.GetIcon();
        public override string AuthorName => "Joe Biellik";
        public override string AuthorWebsite => "https://github.com/JoeBiellik/clipup";
        public override long MaxSize => 1024 * 512; // 512KB

        /// <summary>
        /// Gets or sets the upload expiry time.
        /// Defaults to 1 hour.
        /// User configurable.
        /// </summary>
        [DefaultValue("1H")]
        public string Expiry { get; set; } = "1H";

        /// <summary>
        /// Gets or sets the upload visibility level.
        /// Defaults to unlisted.
        /// User configurable.
        /// </summary>
        [DefaultValue(1)]
        public string Visibility { get; set; } = "1";

        public override async Task<UploadResult> UploadText(TextUploadOptions options, string text)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, options.UserAgent);

                var responce = Encoding.Default.GetString(await client.UploadValuesTaskAsync(UPLOAD_URL, "POST", new NameValueCollection
                {
                    {"api_option", "paste"},
                    {"api_dev_key", KEY},
                    {"api_user_key", string.Empty},             // Guest
                    {"api_paste_private", this.Visibility},     // 0=public 1=unlisted 2=private
                    {"api_paste_name", string.Empty},           // Name
                    {"api_paste_code", text},                   // Text
                    {"api_paste_expire_date", this.Expiry},     // Expiry
                    {"api_paste_format", "text"}                // Highlighting
                }));

                if (responce.StartsWith("Bad API request"))
                {
                    return new UploadResult
                    {
                        Success = false,
                        Message = responce
                    };
                }

                return new UploadResult
                {
                    Success = true,
                    Url = responce
                };
            }
        }

        public void Configure(Control.ControlCollection controls)
        {
            controls.Add(new Label
            {
                AutoSize = true,
                Location = new Point(5, 5),
                TabIndex = 0,
                Text = "Upload expiry"
            });

            var comboBoxExpiry = new ComboBox
            {
                AutoSize = true,
                Location = new Point(85, 2),
                TabIndex = 1,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = this.expiries,
                ValueMember = "Key",
                DisplayMember = "Value"
            };

            comboBoxExpiry.SelectedIndexChanged += (s, e) =>
            {
                this.Expiry = ((KeyValuePair<string, string>)comboBoxExpiry.SelectedItem).Key;
            };

            controls.Add(comboBoxExpiry);

            comboBoxExpiry.SelectedValue = this.Expiry;

            controls.Add(new Label
            {
                AutoSize = true,
                Location = new Point(5, 35),
                TabIndex = 2,
                Text = "Upload privacy"
            });

            var comboBoxVisibility = new ComboBox
            {
                AutoSize = true,
                Location = new Point(85, 32),
                TabIndex = 3,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = this.visibility,
                ValueMember = "Key",
                DisplayMember = "Value"
            };

            comboBoxVisibility.SelectedIndexChanged += (s, e) =>
            {
                this.Visibility = ((KeyValuePair<string, string>)comboBoxVisibility.SelectedItem).Key;
            };

            controls.Add(comboBoxVisibility);

            comboBoxVisibility.SelectedValue = this.Visibility;
        }
    }
}
