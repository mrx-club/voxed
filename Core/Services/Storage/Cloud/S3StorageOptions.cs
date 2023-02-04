namespace Core.Services.Storage.Cloud
{
    public class S3StorageOptions
    {
        public const string SectionName = "S3Storage";

        public string BucketName { get; init; }
    }
}
