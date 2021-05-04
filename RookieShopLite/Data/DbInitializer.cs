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
                new Product{ ProductName = "IPhone", BrandId = 2, CategoryId = 1, ProductShortDescription = "Iphone", ProductFullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas nec pellentesque risus. Morbi efficitur ultricies augue sed porttitor. Vestibulum accumsan dignissim ex, at tempus nibh faucibus sed. Fusce venenatis porta mi quis rhoncus. Integer vestibulum congue nulla, maximus sollicitudin mi congue id. Suspendisse et urna nulla. Donec sed tortor in quam convallis placerat. Praesent placerat urna vel augue pretium egestas. Praesent nibh purus, maximus a dui eget, rutrum interdum lacus.", isDeleted = false, ProductPriceNow = 200},
                new Product{ ProductName = "Samsung", BrandId = 1, CategoryId = 1, ProductShortDescription = "Samsung", ProductFullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas nec pellentesque risus. Morbi efficitur ultricies augue sed porttitor. Vestibulum accumsan dignissim ex, at tempus nibh faucibus sed. Fusce venenatis porta mi quis rhoncus. Integer vestibulum congue nulla, maximus sollicitudin mi congue id. Suspendisse et urna nulla. Donec sed tortor in quam convallis placerat. Praesent placerat urna vel augue pretium egestas. Praesent nibh purus, maximus a dui eget, rutrum interdum lacus.", isDeleted = false, ProductPriceNow = 250, ProductPriceBefore = 350}
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            var images = new ProductImage[] 
            {
                new ProductImage { ProductId = 1, imgPath = "https://res.cloudinary.com/dfzg0xvjj/image/upload/v1620126369/eh44lrm9yds8aa8opgzz.jpg", isDeleted = false },
                new ProductImage { ProductId = 2, imgPath = "https://res.cloudinary.com/dfzg0xvjj/image/upload/v1620126419/yhsawbzapn897nfmlfyi.jpg", isDeleted = false },
                new ProductImage { ProductId = 1, imgPath = "https://res.cloudinary.com/dfzg0xvjj/image/upload/v1620126526/fohql1utma2ffvmx4mbz.jpg", isDeleted = false }
            };

            context.Images.AddRange(images);
            context.SaveChanges();
        }
    }
}
