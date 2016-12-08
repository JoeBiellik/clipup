using System;
using System.Drawing;
using System.Threading.Tasks;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Sdk.Providers
{
    /// <summary>
    /// Provides an abstract image upload provider.
    /// </summary>
    public abstract class ImageUploadProvider : UploadProvider, IImageUploadProvider
    {
        /// <inheritdoc />
        public abstract Task<UploadResult> UploadImage(ImageUploadOptions options, Image image, IProgress<int> progress);
    }
}
