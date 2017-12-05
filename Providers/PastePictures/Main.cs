using System;
using System.Collections.Generic;
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

namespace ClipUp.Providers.PastePictures
{
    public class PastePictures : ImageUploadProvider, IConfigurableProvider
    {
        private const string UPLOAD_URL = "https://paste.pictures/";

        private readonly BindingList<KeyValuePair<uint, string>> periods = new BindingList<KeyValuePair<uint, string>>
        {
            new KeyValuePair<uint, string>(60, "Minutes"),
            new KeyValuePair<uint, string>(3600, "Hours"),
            new KeyValuePair<uint, string>(86400, "Days"),
            new KeyValuePair<uint, string>(604800, "Weeks"),
            new KeyValuePair<uint, string>(2592000, "Months"),
            new KeyValuePair<uint, string>(31536000, "Years")
        };

        public override string Name => "paste.pictures";
        public override Version Version => new Version(1, 0, 0);
        public override string Website => "https://paste.pictures/";
        public override string Description => "paste.pictures image upload";
        public override Icon Icon => this.GetIcon();
        public override string AuthorName => "Joe Biellik";
        public override string AuthorWebsite => "https://github.com/JoeBiellik/clipup";
        public override long MaxSize => 1024 * 1024 * 50; // 50MB

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

        public override async Task<UploadResult> UploadImage(ImageUploadOptions options, Image image, IProgress<int> progress)
        {
            var multipartUpload = new MultipartUpload();

            multipartUpload.Forms.Add(new KeyValuePair<string, object>("expire", (this.ExpiryDuration * this.periods.First(d => d.Value == this.ExpiryPeriod).Key).ToString()));

            multipartUpload.Files.Add(new MultipartFile
            {
                FieldName = "file",
                FileName = "upload." + options.Extension,
                ContentType = options.MimeType,
                Data = image.ToArray(options.Format)
            });

            var percent = 0;

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = multipartUpload.ContentType;
                client.Headers.Add(HttpRequestHeader.UserAgent, options.UserAgent);

                client.UploadProgressChanged += (s, e) =>
                {
                    if (progress == null) return;

                    var current = (int)(e.BytesSent / (double)e.TotalBytesToSend * 100);

                    if (current == percent) return;

                    percent = current;
                    progress.Report(current);
                };

                var result = await client.UploadDataTaskAsync(UPLOAD_URL, multipartUpload.RequestData);

                return new UploadResult
                {
                    Success = true,
                    Url = Encoding.Default.GetString(result)
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
