﻿using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClipUp.Sdk;
using ClipUp.Sdk.Providers;

namespace ClipUp.Providers.PasteFyi
{
    public class PasteFyi : TextUploadProvider
    {
        private const string UPLOAD_URL = "http://paste.fyi/";

        public override string Name => "paste.fyi";
        public override Version Version => new Version(1, 0, 0);
        public override string Link => "http://paste.fyi/";
        public override string Description => "paste.fyi text upload";
        public override long MaxSize => -1;

        public override async Task<UploadResult> UploadText(TextUploadOptions options, string text)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, options.UserAgent);

                var responce = Encoding.Default.GetString(await client.UploadValuesTaskAsync(UPLOAD_URL, "POST", new NameValueCollection
                {
                    {"paste", text}
                }));

                return new UploadResult
                {
                    Success = true,
                    Url = responce
                };
            }
        }
    }
}
