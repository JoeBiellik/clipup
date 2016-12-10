using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ClipUp.Sdk;
using ClipUp.Sdk.Providers;

namespace ClipUp.Providers.Imgur
{
    public class Imgur : ImageUploadProvider
    {
        private const string UPLOAD_URL = "https://api.imgur.com/3/image.json";
        private const string KEY = "915b9718109621a";

        public override string Name => "Imgur";
        public override Version Version => new Version(1, 0, 0);
        public override string Website => "https://imgur.com/";
        public override string Description => "Imgur.com image upload";
        public override Icon Icon => this.GetIcon();
        public override string AuthorName => "Joe Biellik";
        public override string AuthorWebsite => "https://github.com/JoeBiellik/clipup";
        public override long MaxSize => -1;

        public override async Task<UploadResult> UploadImage(ImageUploadOptions options, Image image, IProgress<int> progress)
        {
            var percent = 0;

            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, options.UserAgent);
                client.Headers.Add(HttpRequestHeader.Authorization, "Client-ID " + KEY);

                client.UploadProgressChanged += (s, e) =>
                {
                    if (progress == null) return;

                    var current = (int)(e.BytesSent / (double)e.TotalBytesToSend * 100);

                    if (current == percent) return;

                    percent = current;
                    progress.Report(current);
                };

                var result = await client.UploadValuesTaskAsync(new Uri(UPLOAD_URL), "POST", new NameValueCollection
                {
                    {"image", Convert.ToBase64String(image.ToArray(options.Format))}
                });

                var json = new JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(Encoding.Default.GetString(result));

                return new UploadResult
                {
                    Success = true,
                    Url = json["data"]["link"]
                };
            }
        }
    }
}
