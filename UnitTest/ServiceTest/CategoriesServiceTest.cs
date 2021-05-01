using MyShop.Backend.IntegrationTests;
using RookieShopLite;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.ServiceTest
{
    public class BrandApiTests : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        private readonly TestWebApplicationFactory<Startup> _factory;

        public BrandApiTests(TestWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        //[Fact]
        //public async Task GetBrands_Success()
        //{
        //    var client = _factory.CreateClient();
        //    var response = await client.GetAsync("api/categories");

        //    response.EnsureSuccessStatusCode();
        //    var brands = await response.Content.ReadAsStreamAsync<IEnumerable<BrandViewModel>>();
        //    Assert.NotEmpty(brands);
        //}

        //[Fact]
        //public async Task CreateBrand_NoAuthen_ReturnUnauthorized()
        //{
        //    var client = _factory.CreateClient();
        //    var brand = new BrandCreateRequest { BrandName = "Test brand unauthenticate" };

        //    var response = await client.PostAsJsonAsync("api/brands", brand);

        //    Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        //}

        [Fact]
        public async Task PostBrand_EmptyName_ReturnBadRequest()
        {
            var client = _factory.CreateClient();
            var brand = new BrandCreateRequest { BrandName = "" };

            var response = await client.PostAsJsonAsync("api/brands", brand);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostBrand_Authenticated_Success()
        {
            var client = _factory.CreateClient();
            var brand = new BrandCreateRequest { BrandName = "Test brand authenticated" };

            var response = await client.PostAsJsonAsync("api/brands", brand);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}