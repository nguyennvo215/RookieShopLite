using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Model
{
    public class CartProduct : BaseEntity
    {
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPriceBefore { get; set; }
        public decimal ProductPriceNow { get; set; }
        public string imgPath { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
