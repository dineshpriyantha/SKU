using SKU.Model;
using System.Net;

namespace SKU.Services
{
    public class ShelfManager : IShelfManager
    {
        private readonly IConfiguration _configuration;
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

        public async Task<List<LaneWithSkuViewModel>> GetShelfCabinets()
        {
            using (var client = GetHttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("Shelf/GetCabinets");
                    if(response.IsSuccessStatusCode)
                    {
                        var cabinets = response.Content.ReadAsAsync<List<LaneWithSkuViewModel>>().Result;
                        return cabinets;
                    }
                    else
                    {
                        return new List<LaneWithSkuViewModel>();
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
