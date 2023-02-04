namespace Voxed.WebApp.Models
{
    public class VoxedAttachment
    {
        public string Preview { get; set; }
        public string Extension { get; set; }
        public string ExtensionData { get; set; }

        public bool HasData()
        {
            return Preview != null && Extension != null && ExtensionData != null;
        }
    }
}
