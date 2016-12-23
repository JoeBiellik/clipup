using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using ClipUp.Sdk.Providers;

namespace ClipUp.Sdk
{
    /// <summary>
    /// Extension method helpers for image operations.
    /// </summary>
    public static class ImageExtensions
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
    /// Extension method helpers for upload providers.
    /// </summary>
    public static class UploadProviderExtensions
    {
        /// <summary>
        /// Gets a resource stream embedded in a provider assembly.
        /// </summary>
        /// <param name="provider">The provider type to extract from.</param>
        /// <param name="name">The resource name.</param>
        /// <returns>A stream read from the resource.</returns>
        public static Stream GetResource(this UploadProvider provider, string name)
        {
            var type = provider.GetType();

            return Assembly.GetAssembly(type).GetManifestResourceStream($"{type.Namespace}.{name}");
        }

        /// <summary>
        /// Gets an icon from a resource stream embedded in a provider assembly.
        /// </summary>
        /// <param name="provider">The provider type to extract from.</param>
        /// <param name="name">The icon resource name.</param>
        /// <returns>An icon read from the resource stream.</returns>
        public static Icon GetIcon(this UploadProvider provider, string name = "Icon.ico")
        {
            try
            {
                return new Icon(provider.GetResource(name));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Extension method helpers for stream operations.
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
