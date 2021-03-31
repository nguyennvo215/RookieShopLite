using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RookieShopLite.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShopLite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RetailDetail> RetailDetails { get; set; }
    }
}
