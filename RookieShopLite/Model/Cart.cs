using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            Products = new HashSet<Product>();
        }
        [Required]
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime AddedDate { get; set; }
        public bool isCheckedOut { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
