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
                new Category{ CategoryName = "Phone", isDeleted = false},
                new Category{ CategoryName = "Tablet", isDeleted = false},
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var brands = new Brand[]
            {
                new Brand{ BrandName = "Apple", isDeleted = false},
                new Brand{ BrandName = "Samsung", isDeleted = false},
            };

            context.Brands.AddRange(brands);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{ ProductName = "IPhone", BrandId = 1, CategoryId = 1, ProductShortDescription = "Iphone", isDeleted = false},
                new Product{ ProductName = "Samsung", BrandId = 2, CategoryId = 1, ProductShortDescription = "Samsung", isDeleted = false},
            };

            context.Products.AddRange(products);
            context.SaveChanges();


        }
    }
}
