using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
        }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductFullDescription { get; set; }
        public decimal ProductPriceNow { get; set; }
        public decimal ProductPriceBefore { get; set; }
        public bool isDeleted { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
