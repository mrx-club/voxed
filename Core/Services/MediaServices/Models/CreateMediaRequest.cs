using Microsoft.AspNetCore.Http;

namespace Core.Services.MediaServices.Models
{
    public class CreateMediaRequest
    {
        public string Extension { get; set; }
        public string ExtensionData { get; set; }
        public IFormFile File { get; set; }
    }
}
