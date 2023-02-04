using System.IO;

namespace Core.Services.Storage.Models;

public class StorageObject
{
    public string Key { get; set; }
    public string ContentType { get; set; }
    public Stream Content { get; set; }
}
