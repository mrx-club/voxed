namespace Core.Services.Storage.Local
{
    public class LocalStorageOptions
    {
        public const string SectionName = "LocalStorage";
        public string BaseDirectory { get; init; }
    }
}
