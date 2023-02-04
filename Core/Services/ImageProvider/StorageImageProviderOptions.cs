namespace Core.Services.ImageProvider
{
    public class StorageImageProviderOptions
    {
        public const string SectionName = "StorageImageProvider";
        public string BucketName { get; set; }
        public string AccessKey { get; set; }
        public string AccessSecret { get; set; }
        public string Region { get; set; }
    }
}
