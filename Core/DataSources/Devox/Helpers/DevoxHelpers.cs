using Core.DataSources.Devox.Models;

namespace Core.DataSources.Devox.Helpers
{
    public static class DevoxHelpers
    {
        public static string GetThumbnailUrl(Vox vox)
        {
            if (vox.IsURL)
            {
                if (vox.FileExtension == "video")
                    return $"https://img.youtube.com/vi/{vox.Url}/0.jpg";

                return vox.Url;
            }

            return $"https://devox.uno/backgrounds/low-res_{vox.Filename}.jpeg";
        }
    }
}
