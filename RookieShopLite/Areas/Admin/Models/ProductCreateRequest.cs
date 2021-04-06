using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.Models
{
    public class ProductCreateRequest
    {
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductFullDescription { get; set; }
        public double ProductPriceNow { get; set; }
        public double ProductPriceBefore { get; set; }
        public string imgPath { get; set; }
    }
}
