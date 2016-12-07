namespace ClipUp.Sdk
{
    /// <summary>
    /// File to be uploaded as part of a multipart upload request.
    /// </summary>
    public class MultipartFile
    {
        /// <summary>
        /// Gets or sets the name of the upload field.
        /// </summary>
        /// <value>The upload field name.</value>
        public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets the file name of the upload.
        /// </summary>
        /// <value>The upload file name.</value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the data of the upload.
        /// </summary>
        /// <value>The upload data.</value>
        public byte[] Data { get; set; }

        /// <summary>
        /// Gets or sets the content type of the upload.
        /// </summary>
        /// <value>The upload content type.</value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the transfer encoding of the upload.
        /// </summary>
        /// <value>The upload content transfer encoding.</value>
        public string ContentTransferEncoding { get; set; } = "binary";
    }
}
