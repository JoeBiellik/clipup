using System.Threading.Tasks;

namespace ClipUp.Sdk.Interfaces
{
    public interface ITextUploadProvider : IUploadProvider
    {
        Task<UploadResult> UploadText(TextUploadOptions options, string text);
    }
}
