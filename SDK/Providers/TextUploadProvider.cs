using System;
using System.Threading.Tasks;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Sdk.Providers
{
    public abstract class TextUploadProvider : ITextUploadProvider
    {
        public abstract string Name { get; }
        public abstract Version Version { get; }
        public abstract string Link { get; }
        public abstract string Description { get; }
        public abstract long MaxSize { get; }

        public abstract Task<UploadResult> UploadText(TextUploadOptions options, string text);

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
