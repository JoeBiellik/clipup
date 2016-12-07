using System;
using System.Drawing;
using System.Threading.Tasks;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Sdk.Providers
{
    /// <summary>
    /// Provides an abstract image upload provider.
    /// </summary>
    public abstract class ImageUploadProvider : IImageUploadProvider
    {
        /// <inheritdoc />
        public abstract string Name { get; }

        /// <inheritdoc />
        public abstract Version Version { get; }

        /// <inheritdoc />
        public abstract string Website { get; }

        /// <inheritdoc />
        public abstract string Description { get; }

        /// <inheritdoc />
        public abstract string AuthorName { get; }

        /// <inheritdoc />
        public abstract string AuthorWebsite { get; }

        /// <inheritdoc />
        public abstract long MaxSize { get; }

        /// <inheritdoc />
        public abstract Task<UploadResult> UploadImage(ImageUploadOptions options, Image image, IProgress<int> progress);

        /// <inheritdoc />
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
