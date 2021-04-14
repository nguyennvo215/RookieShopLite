using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.ViewModel
{
    public class CartProductViewModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPriceBefore { get; set; }
        public decimal ProductPriceAfter { get; set; }
        public string imgPath { get; set; }
    }
}
