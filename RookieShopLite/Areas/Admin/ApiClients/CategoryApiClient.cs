using RookieShopLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiClients
{
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<CategoryViewModel>> GetCategories()
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/categories");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<CategoryViewModel>>();
        }
    }
}
