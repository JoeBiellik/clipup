using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ClipUp.Sdk.Interfaces
{
    public interface IImageUploadProvider : IUploadProvider
    {
        Task<UploadResult> UploadImage(ImageUploadOptions options, Image image, IProgress<int> progress);
    }
}
