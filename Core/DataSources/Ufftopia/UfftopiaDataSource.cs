using Core.DataSources.Ufftopia.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.DataSources.Ufftopia
{
    public interface IUfftopiaDataSource
    {
        Task<IEnumerable<LoadMoreResponse>> Fetch();
    }

    public class UfftopiaDataSource : IUfftopiaDataSource
    {
        private readonly HttpClient httpClient = new(new HttpClientHandler());

        public async Task<IEnumerable<LoadMoreResponse>> Fetch()
        {
            //var handler = new HttpClientHandler();

            // If you are using .NET Core 3.0+ you can replace `~DecompressionMethods.None` to `DecompressionMethods.All`
            //handler.AutomaticDecompression = DecompressionMethods.All;

            // In production code, don't destroy the HttpClient through using, but better use IHttpClientFactory factory or at least reuse an existing HttpClient instance
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests
            // https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
            Console.WriteLine(DateTimeOffset.Now.ToString("s"));
            //using var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ufftopia.net/api/Hilo/CargarMas?ultimoBump=2022-11-28T23:22:52.0090765%2B00:00&categorias=19,3,24,35,4,30,5,7,40,16,29,21,18,41,31,8,6,1,11,10,12,42,9,39,13,25,43,32,14,15,17,38,37,26,23,22,36,20");
            using var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://ufftopia.net/api/Hilo/CargarMas?ultimoBump={DateTimeOffset.Now:s}&categorias=19,3,24,35,4,30,5,7,40,16,29,21,18,41,31,8,6,1,11,10,12,42,9,39,13,25,43,32,14,15,17,38,37,26,23,22,36,20");
            request.Headers.TryAddWithoutValidation("authority", "ufftopia.net");
            request.Headers.TryAddWithoutValidation("accept", "application/json, text/plain, */*");
            request.Headers.TryAddWithoutValidation("accept-language", "en-GB,en-US;q=0.9,en;q=0.8,es;q=0.7");
            request.Headers.TryAddWithoutValidation("cookie", "categoriasActivas=[19%2C3%2C24%2C35%2C4%2C30%2C5%2C7%2C40%2C16%2C29%2C21%2C18%2C41%2C31%2C8%2C6%2C1%2C11%2C10%2C12%2C42%2C9%2C39%2C13%2C25%2C43%2C32%2C14%2C15%2C17%2C38%2C37%2C26%2C23%2C22%2C36%2C20]; categoriasFavoritas=[1%2C3%2C6%2C10]; .AspNetCore.Antiforgery.7hiLHkU-i2U=CfDJ8OV41YtSGCZFtr15afyonkMYsJaEazP7YzSbT1gq36J3KHBHHVHCDyw5uf9vJNKrJ6z2I6TG8dGljFOOhzGZrRJA8S1I3gwiiUuMGtO7R6Tix8lM-hW0XyRy2UBMPUiuovog4XC7cinQpr062OH8HuE; .AspNetCore.Identity.Application=CfDJ8OV41YtSGCZFtr15afyonkPS-RkmDh0COsPy8yOSvE2oFETeIUMU_diURE5OFNEPEX9mgcXUSxMkQmZhTxtb1nQ5zhrTnmiFANl11T7nETklRknjfxMA0sf6X9fFTdy56Oub6E1ToO6mXfQuZPG07_reXs_EQVztukwuIuacNWnHNDIhTFztfc3tsiuVt090TP_qwbiMllHH4OXN4lPcztNF8tdbGdRJ3JVXXwyeSuopNCxqrtH6RiXjTOf_XRmGbltJ59MxkrmkyunyD2AVcjfx3iTJJLBO3kDCQvAeuqGlDbDm4kbljybXCm7K1hf2HzaUuwq79EpY9hiVY6jjTtSOysEG0aSd4jrZeqYV8YU2CW4Q4cmWn7IR8LxUY-vOW6DKByl9TK4qlaxjzFVY7EwoAXQpBIhXjifOELUFUntxSRbtWSe1lIzLPmfi-QznZ1RYqCZBzPX6iVmY39YULzNyYtgO-nEsVyraWNMmvjS73e_XVrp7tZF-ymdqwSx2UJXyzHTpup2tVfL1D-_YIMD-XUsJeROWYF8-4U_N29g83juopRu4OlPr6p7BVaOygjvQO9E5Rwcq29tmhg1w-0Kk0v6GV95aQqy3kd031QRLOVXI961Cy93rWGUrOW0QuJ6VeLAJYJDM2Cz7D4BfhqC5ihVyOIu8Fm74SInErBu0szxkzQTmHfEz2X6FuM0kgw");
            request.Headers.TryAddWithoutValidation("requestverificationtoken", "CfDJ8OV41YtSGCZFtr15afyonkNwPRXTbfDJE9cxji4ya8UABxGNEYbcQ1jnUjBdZ6tQ31JxdHQkpRROHAnGTYy-0h_WSHVh3p1KNTl2oIZnpvg8tjVyPBhJpACQ4JdvOjjTTPI-cnxDFCuV85FanGyd2kpYOTOAQb5XKug8lxghQI9ZfM7a3ywjldyCkIRlgf0z_Q");
            request.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Google Chrome\";v=\"107\", \"Chromium\";v=\"107\", \"Not=A?Brand\";v=\"24\"");
            request.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?1");
            request.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Android\"");
            request.Headers.TryAddWithoutValidation("sec-fetch-dest", "empty");
            request.Headers.TryAddWithoutValidation("sec-fetch-mode", "cors");
            request.Headers.TryAddWithoutValidation("sec-fetch-site", "same-origin");
            request.Headers.TryAddWithoutValidation("user-agent", "Mozilla/5.0 (Linux; Android 12; SM-G998B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Mobile Safari/537.36");

            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<LoadMoreResponse>();

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return JsonConvert.DeserializeObject<IEnumerable<LoadMoreResponse>>(await response.Content.ReadAsStringAsync());
        }
    }
}
