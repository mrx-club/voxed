namespace Core.Utilities
{
    public static class UrlUtility
    {
        public static string GetFileExtensionFromUrl(string url)
        {
            var array = url.Split(".");
            return array[^1];
        }

        public static string GetFileNameFromUrl(string url)
        {
            return url.Split('/')[^1];
        }
    }
}
