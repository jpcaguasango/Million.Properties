using Million.Properties.Domain.Ports;
using Newtonsoft.Json;

namespace Application.Services
{
    public class UnsplashService: IUnsplashService
    {
        private static readonly Random random = new Random();
        private readonly HttpClient _httpClient;
        private const string AccessKey = "4ofV1aW3goksQPPubJSjd_k4YT2SXj8-P7J9Mr9u2UA";
        private const string BaseUrl = "https://api.unsplash.com";

        public UnsplashService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SearchImagenAsync(string query)
        {
            var url = $"{BaseUrl}/search/photos?query={Uri.EscapeDataString(query)}&client_id={AccessKey}&per_page=30";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return "";
            }

            var json = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(json);
            string? imageUrl = result?.results[random.Next(0, 29)]?.urls?.regular ?? "";

            return imageUrl;
        }
    }
}

