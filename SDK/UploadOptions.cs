using System;
using System.Drawing.Imaging;
using System.Linq;

namespace ClipUp.Sdk
{
    /// <summary>
    /// An abstract upload options class. Provides common options to the <see cref="TextUploadOptions"/> and <see cref="ImageUploadOptions"/> concreate classes.
    /// </summary>
    public abstract class UploadOptions
    {
        /// <summary>
        /// Gets or sets the useragent used when uploading.
        /// </summary>
        /// <value>The useragent.</value>
        public string UserAgent { get; set; }
    }

    /// <summary>
    /// Represents the options used by <see cref="Interfaces.ITextUploadProvider"/> to perform a text upload.
    /// </summary>
    /// <seealso cref="UploadOptions"/>
    public class TextUploadOptions : UploadOptions
    {
    }

    /// <summary>
    /// Represents the options used by <see cref="Interfaces.IImageUploadProvider"/> to perform an image upload.
    /// </summary>
    public class ImageUploadOptions : UploadOptions
    {
        /// <summary>
        /// Gets or sets the target image format that should be uploaded.
        /// </summary>
        /// <value>The image format.</value>
        public ImageFormat Format { get; set; } = ImageFormat.Png;

        /// <summary>
        /// Gets or sets the target image MIME type that should be uploaded. Defaults to the MIME used by <see cref="Format"/>.
        /// </summary>
        /// <value>The image MIME type.</value>
        public string MimeType => ImageCodecInfo.GetImageEncoders().First(codec => codec.FormatID == this.Format.Guid).MimeType;

        /// <summary>
        /// Gets or sets the target image file extension that should be uploaded. Defaults to the extension used by <see cref="Format"/>.
        /// </summary>
        /// <value>The image file extension.</value>
        public string Extension => ImageCodecInfo.GetImageEncoders().Where(codec => codec.FormatID == this.Format.Guid).Select(ie => ie.FilenameExtension.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).First().Substring(2).ToLower()).FirstOrDefault() ?? this.Format.ToString().ToLower();
    }
}
