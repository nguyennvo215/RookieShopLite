using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShopLite.Model;

namespace RookieShopLite.Data.Configuration
{
    public class ProductImagesConfiguration : IEntityTypeConfiguration<ProductImages>
    {
        public void Configure(EntityTypeBuilder<ProductImages> builder)
        {
            builder.HasKey(o => new { o.ProductId, o.ImageId });
            builder
                .HasOne(o => o.Product)
                .WithMany(o => o.ProductImages)
                .HasForeignKey(o => o.ImageId);
            builder
                .HasOne(o => o.Image)
                .WithMany(o => o.ProductImages)
                .HasForeignKey(o => o.ImageId);
        }
    }
}
