using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ClipUp.Sdk.Interfaces
{
    /// <summary>
    /// Interface implemented by all providers supporting image uploads.
    /// <seealso cref="IUploadProvider"/>
    /// </summary>
    public interface IImageUploadProvider : IUploadProvider
    {
        /// <summary>
        /// Uploads an image.
        /// </summary>
        /// <param name="options">The upload options.</param>
        /// <param name="image">The image to upload.</param>
        /// <param name="progress">The progress provider to call with upload percentage updates.</param>
        Task<UploadResult> UploadImage(ImageUploadOptions options, Image image, IProgress<int> progress = null);
    }
}
