using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ClipUp.Sdk
{
    /// <summary>
    /// Extention method helpers for image operations.
    /// </summary>
    public static class ImageExtentions
    {
        /// <summary>
        /// Converts an image into a byte array.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="format">The format to convert the <see cref="image"/> to.</param>
        /// <returns>A byte array representing the image converted to the target format.</returns>
        public static byte[] ToArray(this Image image, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, format);

                return ms.ToArray();
            }
        }
    }

    /// <summary>
    /// Extention method helpers for stream operations.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Write a string to a stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="value">The ASCII value to write.</param>
        public static void WriteString(this Stream stream, string value)
        {
            var buffer = Encoding.ASCII.GetBytes(value);

            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
