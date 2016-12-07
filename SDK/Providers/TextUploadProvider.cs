using System;
using System.Threading.Tasks;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Sdk.Providers
{
    /// <summary>
    /// Provides an abstract text upload provider.
    /// </summary>
    public abstract class TextUploadProvider : ITextUploadProvider
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
        public abstract Task<UploadResult> UploadText(TextUploadOptions options, string text);

        /// <inheritdoc />
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
