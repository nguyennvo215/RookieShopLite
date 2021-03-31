using System;
using System.Collections.Generic;

namespace RookieShopLite.Model
{
    public class RetailDetail : BaseEntity
    {
        public RetailDetail()
        {
            Cart = new HashSet<Cart>();
        }
        public double TotalPrice { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
