using Core.Services.Storage.Models;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core.Services.Storage.Local
{
    public class LocalStorage : IStorage
    {
        private readonly LocalStorageOptions _options;

        public LocalStorage(IOptions<LocalStorageOptions> options)
        {
            _options = options.Value;
        }

        public async Task Save(StorageObject obj)
        {
            var path = Path.Combine("wwwroot", _options.BaseDirectory, obj.Key);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            obj.Content.Seek(0, SeekOrigin.Begin);
            await obj.Content.CopyToAsync(fileStream);
        }
    }
}
