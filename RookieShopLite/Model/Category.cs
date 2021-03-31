using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [Required]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; private set; }
    }
}
