using Microsoft.AspNetCore.Mvc;
using RookieShopLite.Areas.Admin.Apis;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.ControllerTest
{
    public class CategoriesControllerTest : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public CategoriesControllerTest(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task PostCategory_Success()
        {
            var dbContext = _fixture.Context;
            var category = new CategoryCreateRequest { CategoryName = "Test category" };

            var controller = new CategoriesController(dbContext);
            var result = await controller.PostCategory(category);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<CategoryViewModel>(createdAtActionResult.Value);
            Assert.Equal("Test category", returnValue.CategoryName);
        }
    }
}
