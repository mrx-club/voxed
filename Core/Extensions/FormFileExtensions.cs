using Microsoft.AspNetCore.Http;
using System.IO;

namespace Core.Extensions
{
    public static class FormFileExtensions
    {
        public static string GetFileExtension(this IFormFile file)
        {
            return Path.GetExtension(file.FileName).ToLowerInvariant();
        }
    }
}
