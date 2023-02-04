using System.IO;
using System.Threading.Tasks;

namespace Core.Services.Image
{
    public interface IImageService
    {
        Task<Stream> Compress(Stream stream);
        Task<Stream> GenerateThumbnail(Stream stream);
        Stream GetStreamFromBase64(string base64);
    }
}