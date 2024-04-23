using SKU.Model;
using System.Net;

namespace SKU.Services
{
    public class ShelfManager : IShelfManager
    {
        private readonly IConfiguration _configuration;
        //private readonly IHttpClient _httpClient;
        public ShelfManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HttpClient GetHttpClient()
        {
            string? apiUrl = _configuration.GetSection("AppSettings")["ApiUrl"];
            if (apiUrl != null)
            {
                var client = new HttpClient()
                {
                    BaseAddress = new Uri(apiUrl)
                };
                return client;
            }
            else
            {
                throw new Exception("Apiurl is not configured");
            }
        }

        public async Task<List<Cabinet>> GetShelfCabinets()
        {
            using (var client = GetHttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("ShelfApi/GetCabinets");
                    if (response.IsSuccessStatusCode)
                    {
                        var cabinets = response.Content.ReadAsAsync<List<Cabinet>>().Result;
                        return cabinets;
                    }
                    else
                    {
                        return new List<Cabinet>();
                    }
                }
                catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
            }            
        }
    }
}
