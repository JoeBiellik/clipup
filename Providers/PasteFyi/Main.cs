using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipUp.Sdk;
using ClipUp.Sdk.Interfaces;
using ClipUp.Sdk.Providers;

namespace ClipUp.Providers.PasteFyi
{
    public class PasteFyi : TextUploadProvider, IConfigurableProvider
    {
        private const string UPLOAD_URL = "http://paste.fyi/";

        private readonly BindingList<KeyValuePair<uint, string>> periods = new BindingList<KeyValuePair<uint, string>>
        {
            new KeyValuePair<uint, string>(60, "Minutes"),
            new KeyValuePair<uint, string>(3600, "Hours"),
            new KeyValuePair<uint, string>(86400, "Days"),
            new KeyValuePair<uint, string>(604800, "Weeks"),
            new KeyValuePair<uint, string>(2592000, "Months"),
            new KeyValuePair<uint, string>(31536000, "Years")
        };

        public override string Name => "paste.fyi";
        public override Version Version => new Version(1, 0, 0);
        public override string Website => "http://paste.fyi/";
        public override string Description => "paste.fyi text upload";
        public override Icon Icon => this.GetIcon();
        public override string AuthorName => "Joe Biellik";
        public override string AuthorWebsite => "https://github.com/JoeBiellik/clipup";
        public override long MaxSize => 1024 * 1024 * 2; // 2MB

        /// <summary>
        /// Gets or sets the upload expiry duration.
        /// Defaults to 1.
        /// User configurable.
        /// </summary>
        [DefaultValue(1)]
        public uint ExpiryDuration { get; set; } = 1;

        /// <summary>
        /// Gets or sets the upload expiry period.
        /// Defaults to "Weeks".
        /// User configurable.
        /// </summary>
        [DefaultValue("Weeks")]
        public string ExpiryPeriod { get; set; } = "Weeks";

        public override async Task<UploadResult> UploadText(TextUploadOptions options, string text)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, options.UserAgent);

                var responce = Encoding.Default.GetString(await client.UploadValuesTaskAsync(UPLOAD_URL, "POST", new NameValueCollection
                {
                    {"paste", text},
                    {"expire", (this.ExpiryDuration * this.periods.First(d => d.Value == this.ExpiryPeriod).Key).ToString()}
                }));

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
                Location = new Point(5, 4),
                TabIndex = 0,
                Text = "Upload expiry"
            });

            var numericUpDownDuration = new NumericUpDown
            {
                AutoSize = true,
                Width = 50,
                Location = new Point(80, 2),
                TabIndex = 1,
                Minimum = 1,
                Maximum = 100,
                Value = this.ExpiryDuration
            };

            numericUpDownDuration.ValueChanged += (s, e) =>
            {
                this.ExpiryDuration = (uint)numericUpDownDuration.Value;
            };

            controls.Add(numericUpDownDuration);

            var comboBoxPeriod = new ComboBox
            {
                AutoSize = true,
                Location = new Point(135, 2),
                TabIndex = 2,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = this.periods,
                ValueMember = "Key",
                DisplayMember = "Value"
            };

            comboBoxPeriod.SelectedIndexChanged += (s, e) =>
            {
                this.ExpiryPeriod = ((KeyValuePair<uint, string>)comboBoxPeriod.SelectedItem).Value;
            };

            controls.Add(comboBoxPeriod);

            comboBoxPeriod.SelectedValue = this.periods.First(d => d.Value == this.ExpiryPeriod).Key;
        }
    }
}
