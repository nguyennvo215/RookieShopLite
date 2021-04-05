using Newtonsoft.Json;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Category
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task DeleteCategory(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.DeleteAsync("api/categories" + $"/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IList<CategoryViewModel>> GetCategories()
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/categories");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<CategoryViewModel>>();
        }

        public async Task<CategoryViewModel> GetCategory(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/categories" + $"/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoryViewModel>();
        }

        public async Task<CategoryViewModel> PostCategory(CategoryCreateRequest categoryCreateRequest)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(categoryCreateRequest);
            var httpContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/categories", httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoryViewModel>();
        }

        public async Task<CategoryViewModel> PutCategory(int id, CategoryCreateRequest categoryCreateRequest)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(categoryCreateRequest);
            var httpContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/categories" + $"/{id}", httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoryViewModel>();
        }
    }
}
