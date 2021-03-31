using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class Brand : BaseEntity
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }
        [Required]
        public string BrandName { get; set; }
        public virtual ICollection<Product> Products { get; private set; }
    }
}
