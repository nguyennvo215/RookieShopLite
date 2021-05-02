using Newtonsoft.Json;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Rating
{
    public class RatingApiService : IRatingApiService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public RatingApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IList<UserRatingViewModel>> GetRatings(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/ratings" + $"/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<UserRatingViewModel>>();
        }

        public async Task<UserRatingViewModel> PostRating(RatingCreateRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/ratings", httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserRatingViewModel>();
        }
    }
}
