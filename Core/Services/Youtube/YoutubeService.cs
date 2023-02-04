using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Services.Youtube
{
    public interface IYoutubeService
    {
        Task<Stream> GetThumbnail(string videoId);
    }

    public class YoutubeService : IYoutubeService
    {
        private readonly HttpClient _client;

        public YoutubeService()
        {
            _client = new HttpClient();
        }

        public async Task<Stream> GetThumbnail(string videoId)
        {
            //var response = await _client.GetAsync($"https://img.youtube.com/vi/{videoId}/maxresdefault.jpg");

            //https://i3.ytimg.com/vi/CHQDYl8t2AA/hqdefault.jpg
            var response = await _client.GetAsync($"https://i3.ytimg.com/vi/{videoId}/maxresdefault.jpg");

            if (!response.IsSuccessStatusCode)
            {
                response = await _client.GetAsync($"https://img.youtube.com/vi/{videoId}/hqdefault.jpg");
            }


            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadAsStreamAsync();
        }
    }
}
