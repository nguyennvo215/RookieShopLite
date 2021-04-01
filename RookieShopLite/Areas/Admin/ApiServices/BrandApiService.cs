using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiClients
{
    public class BrandApiService : IBrandApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<BrandViewModel>> GetBrands()
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/brands");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<BrandViewModel>>();
        }
    }
}
