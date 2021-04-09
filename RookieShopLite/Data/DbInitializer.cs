using RookieShopLite.Model;
using System.Linq;

namespace RookieShopLite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Brands.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category{ CategoryName = "Phone", isDeleted = false},
                new Category{ CategoryName = "Tablet", isDeleted = false}
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var brands = new Brand[]
            {
                new Brand{ BrandName = "Apple", isDeleted = false},
                new Brand{ BrandName = "Samsung", isDeleted = false}
            };

            context.Brands.AddRange(brands);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{ ProductName = "IPhone", BrandId = 2, CategoryId = 1, ProductShortDescription = "Iphone", isDeleted = false, ProductPriceNow = 200},
                new Product{ ProductName = "Samsung", BrandId = 1, CategoryId = 1, ProductShortDescription = "Samsung", isDeleted = false, ProductPriceNow = 250, ProductPriceBefore = 350}
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            var images = new ProductImage[] 
            {
                new ProductImage { ProductId = 1, imgPath = "products/1.jpg", isDeleted = false },
                new ProductImage { ProductId = 2, imgPath = "products/2.jpg", isDeleted = false },
                new ProductImage { ProductId = 1, imgPath = "products/3.jpg", isDeleted = false }
            };

            context.Images.AddRange(images);
            context.SaveChanges();
        }
    }
}
