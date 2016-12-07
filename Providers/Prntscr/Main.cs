using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using ClipUp.Sdk;
using ClipUp.Sdk.Interfaces;
using ClipUp.Sdk.Providers;

namespace ClipUp.Providers.Prntscr
{
    public class Prntscr : ImageUploadProvider, IConfigurableProvider
    {
        public override string Name => "prntscr.com";
        public override Version Version => new Version(1, 0, 0);
        public override string Website => "http://prntscr.com/";
        public override string Description => "prntscr.com image upload";
        public override string AuthorName => "Joe Biellik";
        public override string AuthorWebsite => "https://github.com/JoeBiellik/clipup";
        public override long MaxSize => -1;

        /// <summary>
        /// Gets or sets whether the result URL should be a direct link to the uploaded image.
        /// Defaults to true.
        /// User configurable.
        /// </summary>
        /// <seealso cref="UploadResult.Url"/>
        public bool DirectLink { get; set; } = true;

        public override async Task<UploadResult> UploadImage(ImageUploadOptions options, Image image, IProgress<int> progress)
        {
            var multipartUpload = new MultipartUpload();

            multipartUpload.Files.Add(new MultipartFile
            {
                FieldName = "image",
                FileName = "upload." + options.Extention,
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

                var result = await client.UploadDataTaskAsync("http://prntscr.com/upload.php", multipartUpload.RequestData);

                // TODO: Check result

                var json = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(Encoding.Default.GetString(result));

                return new UploadResult
                {
                    Success = true,
                    Url = this.DirectLink ? json["data"] + "/direct" : json["data"]
                };
            }
        }

        public void Configure(Control.ControlCollection controls)
        {
            var checkboxDirectLink = new CheckBox
            {
                AutoSize = true,
                Location = new Point(5, 5),
                Text = "Link directly to image",
                Checked = this.DirectLink,
                TabIndex = 0
            };

            checkboxDirectLink.CheckedChanged += (s, e) =>
            {
                this.DirectLink = checkboxDirectLink.Checked;
            };

            controls.Add(checkboxDirectLink);
        }
    }
}
