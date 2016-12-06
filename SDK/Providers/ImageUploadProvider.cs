using System;
using System.Drawing;
using System.Threading.Tasks;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Sdk.Providers
{
    public abstract class ImageUploadProvider : IImageUploadProvider
    {
        public abstract string Name { get; }
        public abstract Version Version { get; }
        public abstract string Link { get; }
        public abstract string Description { get; }
        public abstract long MaxSize { get; }

        public abstract Task<UploadResult> UploadImage(ImageUploadOptions options, Image image, IProgress<int> progress);

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
