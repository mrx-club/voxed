using Core.DataSources.Devox.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Core.DataSources.Devox;

public interface IDevoxDataSource
{
    Task GetVox();
    Task<IEnumerable<Vox>> GetVoxes();
    Task<IEnumerable<Vox>> GetMoreVoxes(int count);
}

public class DevoxDataSource : IDevoxDataSource
{
    private readonly HttpClient httpClient = new HttpClient();

    public async Task<IEnumerable<Vox>> GetVoxes()
    {
        using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.devox.uno/getVoxes"))
        {
            request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:108.0) Gecko/20100101 Firefox/108.0");
            request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
            request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.5");
            request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, br");
            request.Headers.TryAddWithoutValidation("Origin", "https://devox.uno");
            request.Headers.TryAddWithoutValidation("DNT", "1");
            request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            request.Headers.TryAddWithoutValidation("Referer", "https://devox.uno/");
            request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
            request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
            request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-site");
            request.Headers.TryAddWithoutValidation("TE", "trailers");

            request.Content = new StringContent("{\"user\":null,\"count\":36,\"oldCount\":0}");
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<Vox>();
            
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

            var respon = JsonConvert.DeserializeObject<GetVoxesResponse>(content);
            return respon.Voxes;
        }
    }

    public async Task<IEnumerable<Vox>> GetMoreVoxes(int count)
    {
        using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.devox.uno/getVoxes"))
        {
            request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:108.0) Gecko/20100101 Firefox/108.0");
            request.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
            request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.5");
            request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, br");
            request.Headers.TryAddWithoutValidation("Origin", "https://devox.uno");
            request.Headers.TryAddWithoutValidation("DNT", "1");
            request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            request.Headers.TryAddWithoutValidation("Referer", "https://devox.uno/");
            request.Headers.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
            request.Headers.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
            request.Headers.TryAddWithoutValidation("Sec-Fetch-Site", "same-site");
            request.Headers.TryAddWithoutValidation("TE", "trailers");
            var req = new { count = count, oldCount = count - 20 };
            //request.Content = new StringContent("{\"user\":null,\"count\":20,\"oldCount\":0}");
            request.Content = new StringContent(JsonConvert.SerializeObject(req));
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<Vox>();

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

            var respon = JsonConvert.DeserializeObject<GetVoxesResponse>(content);
            return respon.Voxes;
        }
    }

    public async Task GetVox()
    {
        //https://api.devox.uno/getVox/c6866acd-8514
        //[{ "poll":[false],"_id":"634f9518129544ad402e3bd3","title":"Nunca se habló del cepillismo de Gandhi","description":"Eso.<br>Decía practicar el celibato, pero \"dormía\" en bolas con niñas","category":39,"filename":"c6866acd-8514","fileExtension":"image","isURL":true,"dice":false,"username":"15b3ee24-f0bd-430a-8429-3b763ac48c77","url":"https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Gandhi_and_Indira_1924.jpg/2560px-Gandhi_and_Indira_1924.jpg","sticky":false,"flag":false,"commentsCount":19,"date":"2022-10-19T06:11:36.980Z","lastUpdate":"2022-11-25T00:26:13.061Z"}]
    }
}
