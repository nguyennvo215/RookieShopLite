using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShopLite.Areas.Admin.Apis;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.Model;
using RookieShopLite.ViewModel;
using System.Linq;
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

        [Fact]
        public async Task PutCategory_Success()
        {
            var dbContext = _fixture.Context;
            dbContext.Categories.Add(new Category { CategoryName = "Test category" });
            await dbContext.SaveChangesAsync();

            var oldCategory = await dbContext.Categories.OrderByDescending(x => x.Id).FirstAsync();
            var category = new CategoryCreateRequest { CategoryName = "Test put category" };

            var controller = new CategoriesController(dbContext);
            var result = await controller.PutCategory(oldCategory.Id, category);

            var returnValue = await dbContext.Categories.OrderByDescending(x => x.Id).FirstAsync();
            Assert.Equal("Test put category", returnValue.CategoryName);
        }
    }
}
