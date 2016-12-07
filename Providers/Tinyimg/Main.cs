using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ClipUp.Sdk;
using ClipUp.Sdk.Providers;

namespace ClipUp.Providers.Tinyimg
{
    public class Tinyimg : ImageUploadProvider
    {
        private const string UPLOAD_URL = "http://tinyimg.io/upload";

        public override string Name => "Tinyimg";
        public override Version Version => new Version(1, 0, 0);
        public override string Link => "http://tinyimg.io/";
        public override string Description => "tinyimg.io image upload";
        public override long MaxSize => -1;

        public override async Task<UploadResult> UploadImage(ImageUploadOptions options, Image image, IProgress<int> progress)
        {
            var multipartUpload = new MultipartUpload();

            multipartUpload.Files.Add(new MultipartFile
            {
                FieldName = "qqfile",
                ContentType = "image/png",
                FileName = "upload.png",
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

                var json = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(Encoding.Default.GetString(result));

                return new UploadResult
                {
                    Success = true,
                    Url = this.Link + "/i/" + json["uploadName"]
                };
            }
        }
    }
}
