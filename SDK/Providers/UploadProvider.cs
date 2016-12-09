using System;
using System.Drawing;

namespace ClipUp.Sdk.Providers
{
    /// <summary>
    /// Provides an abstract general upload provider.
    /// </summary>
    public abstract class UploadProvider
    {
        /// <summary>
        /// SDK version number the provider was built against.
        /// </summary>
        /// <remarks>
        /// This version number is incremented when there is a major change to the SDK.
        /// </remarks>
        public const uint SDK_VERSION = 0;

        /// <inheritdoc />
        public abstract string Name { get; }

        /// <inheritdoc />
        public abstract Version Version { get; }

        /// <inheritdoc />
        public abstract string Website { get; }

        /// <inheritdoc />
        public abstract string Description { get; }

        /// <inheritdoc />
        public abstract Icon Icon { get; }

        /// <inheritdoc />
        public abstract string AuthorName { get; }

        /// <inheritdoc />
        public abstract string AuthorWebsite { get; }

        /// <inheritdoc />
        public abstract long MaxSize { get; }

        /// <inheritdoc />
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
