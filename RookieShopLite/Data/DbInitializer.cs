using RookieShopLite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                new Category{ CategoryName = "Phone"},
                new Category{ CategoryName = "Tablet"},
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var brands = new Brand[]
            {
                new Brand{ BrandName = "Apple"},
                new Brand{ BrandName = "Samsung"},
            };

            context.Brands.AddRange(brands);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{ ProductName = "IPhone", BrandId = 1, CategoryId = 1, ProductShortDescription = "Iphone"},
                new Product{ ProductName = "Samsung", BrandId = 2, CategoryId = 1, ProductShortDescription = "Samsung"},
            };

            context.Products.AddRange(products);
            context.SaveChanges();


        }
    }
}
