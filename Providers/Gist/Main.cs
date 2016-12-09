using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ClipUp.Sdk;
using ClipUp.Sdk.Providers;

namespace ClipUp.Providers.Gist
{
    public class Gist : TextUploadProvider
    {
        private const string UPLOAD_URL = "https://api.github.com/gists";

        public override string Name => "GitHub Gist";
        public override Version Version => new Version(1, 0, 0);
        public override string Website => "https://gist.github.com/";
        public override Icon Icon => new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("ClipUp.Providers.Gist.Icon.ico"));
        public override string Description => "GitHub Gist text upload";
        public override string AuthorName => "Joe Biellik";
        public override string AuthorWebsite => "https://github.com/JoeBiellik/clipup";
        public override long MaxSize => -1;

        public override async Task<UploadResult> UploadText(TextUploadOptions options, string text)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, options.UserAgent);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers.Add(HttpRequestHeader.Accept, "application/vnd.github.v3+json");

                var data = new JavaScriptSerializer().Serialize(new
                {
                    files = new
                    {
                        clipboard = new
                        {
                            content = text
                        }
                    }
                });

                var result = await client.UploadDataTaskAsync(UPLOAD_URL, "POST", Encoding.Default.GetBytes(data));

                // TODO: Check result

                var json = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(Encoding.Default.GetString(result));

                return new UploadResult
                {
                    Success = true,
                    Url = json["html_url"].ToString()
                };
            }
        }
    }
}
