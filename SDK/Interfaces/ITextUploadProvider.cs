using System.Threading.Tasks;

namespace ClipUp.Sdk.Interfaces
{
    /// <summary>
    /// Interface implemented by all providers supporting text uploads.
    /// <seealso cref="IUploadProvider"/>
    /// </summary>
    public interface ITextUploadProvider : IUploadProvider
    {
        /// <summary>
        /// Uploads text.
        /// </summary>
        /// <param name="options">The upload options.</param>
        /// <param name="text">The text to upload.</param>
        Task<UploadResult> UploadText(TextUploadOptions options, string text);
    }
}
