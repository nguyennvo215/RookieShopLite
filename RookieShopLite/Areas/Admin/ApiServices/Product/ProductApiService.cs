using Newtonsoft.Json;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Product
{
    public class ProductApiService : IProductApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task DeleteProduct(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.DeleteAsync("api/products" + $"/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IList<ProductViewModel>> GetProducts()
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/products");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<ProductViewModel>>();
        }

        public async Task<IList<ProductViewModel>> GetProduct(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/products" + $"/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<ProductViewModel>>();
        }

        public async Task<ProductViewModel> PostProduct(ProductCreateRequest productCreateRequest)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(productCreateRequest);
            var httpContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/products", httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductViewModel>();
        }

        public async Task<ProductViewModel> PutProduct(int id, ProductCreateRequest productCreateRequest)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(productCreateRequest);
            var httpContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/products" + $"/{id}", httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductViewModel>();
        }
    }
}
