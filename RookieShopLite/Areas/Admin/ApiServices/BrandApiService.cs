using Newtonsoft.Json;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
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

        public async Task DeleteBrand(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.DeleteAsync("api/brands" + $"/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<BrandViewModel> GetBrand(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/brands" + $"/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BrandViewModel>();
        }

        public async Task<IList<BrandViewModel>> GetBrands()
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/brands");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<BrandViewModel>>();
        }

        public async Task<BrandViewModel> PostBrand(BrandCreateRequest brandCreateRequest)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(brandCreateRequest);
            var httpContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/brands", httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BrandViewModel>();
        }

        public async Task<BrandViewModel> PutBrand(int id, BrandCreateRequest brandCreateRequest)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(brandCreateRequest);
            var httpContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/brands" + $"/{id}", httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BrandViewModel>();
        }
    }
}
