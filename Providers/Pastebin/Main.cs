using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClipUp.Sdk;
using ClipUp.Sdk.Providers;

namespace ClipUp.Providers.Pastebin
{
    public class Pastebin : TextUploadProvider
    {
        private const string UPLOAD_URL = "http://pastebin.com/api/api_post.php";
        private const string KEY = "64269a656668650a05cf01becfb9d05c";

        public override string Name => "Pastebin.com";
        public override Version Version => new Version(1, 0, 0);
        public override string Website => "http://pastebin.com/";
        public override string Description => "Pastebin.com text upload";
        public override Icon Icon => this.GetIcon();
        public override string AuthorName => "Joe Biellik";
        public override string AuthorWebsite => "https://github.com/JoeBiellik/clipup";
        public override long MaxSize => -1;

        public override async Task<UploadResult> UploadText(TextUploadOptions options, string text)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, options.UserAgent);

                var responce = Encoding.Default.GetString(await client.UploadValuesTaskAsync(UPLOAD_URL, "POST", new NameValueCollection
                {
                    {"api_option", "paste"},
                    {"api_dev_key", KEY},
                    {"api_user_key", string.Empty},     // Guest
                    {"api_paste_private", "1"},         // 0=public 1=unlisted 2=private
                    {"api_paste_name", string.Empty},   // Name
                    {"api_paste_code", text},           // Text
                    {"api_paste_expire_date", "10M"},   // Expiry
                    {"api_paste_format", "text"}        // Highlighting
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
    }
}
