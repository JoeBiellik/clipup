namespace ClipUp.Sdk
{
    /// <summary>
    /// Represents the result of an upload operation.
    /// </summary>
    /// <seealso cref="Interfaces.ITextUploadProvider"/>
    /// <seealso cref="Interfaces.IImageUploadProvider"/>
    public class UploadResult
    {
        /// <summary>
        /// Gets or sets the upload success flag.
        /// </summary>
        /// <value>Whether the upload was successful.</value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the upload status message.
        /// </summary>
        /// <value>The upload message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the URL to the uploaded item.
        /// </summary>
        /// <value>The URL to the uploaded content.</value>
        public string Url { get; set; }
    }
}
