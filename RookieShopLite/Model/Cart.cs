using System;
using System.Collections.Generic;

namespace RookieShopLite.Model
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            Products = new HashSet<Product>();
        }
        public int UserId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime AddedDate { get; set; }
        public bool isCheckedOut { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
