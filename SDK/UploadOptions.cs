using System;
using System.Drawing.Imaging;
using System.Linq;

namespace ClipUp.Sdk
{
    public abstract class UploadOptions
    {
        public string UserAgent { get; set; }
    }


    public class TextUploadOptions : UploadOptions
    {

    }

    public class ImageUploadOptions : UploadOptions
    {
        public ImageFormat Format { get; set; } = ImageFormat.Png;
        public string MimeType => ImageCodecInfo.GetImageEncoders().First(codec => codec.FormatID == this.Format.Guid).MimeType;
        public string Extention => ImageCodecInfo.GetImageEncoders().Where(codec => codec.FormatID == this.Format.Guid).Select(ie => ie.FilenameExtension.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries).First().Substring(2).ToLower()).FirstOrDefault() ?? this.Format.ToString().ToLower();
    }
}
