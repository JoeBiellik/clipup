using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ClipUp.Sdk
{
    public static class ImageExtentions
    {
        public static byte[] ToArray(this Image image, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, format);

                return ms.ToArray();
            }
        }
    }

    public static class StreamExtensions
    {
        public static void WriteString(this Stream stream, string value)
        {
            var buffer = Encoding.ASCII.GetBytes(value);

            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
