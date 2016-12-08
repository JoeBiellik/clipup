using System;
using System.Drawing;
using System.Threading.Tasks;
using ClipUp.Sdk.Interfaces;

namespace ClipUp.Sdk.Providers
{
    /// <summary>
    /// Provides an abstract text upload provider.
    /// </summary>
    public abstract class TextUploadProvider : UploadProvider, ITextUploadProvider
    {
        /// <inheritdoc />
        public abstract Task<UploadResult> UploadText(TextUploadOptions options, string text);
    }
}
