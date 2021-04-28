using System.Collections.Generic;

namespace RookieShopLite.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public double BrandId { get; set; }
        public double CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductFullDescription { get; set; }
        public decimal ProductPriceNow { get; set; }
        public decimal ProductPriceBefore { get; set; }
        public List<string> images { get; set; }
        public bool isDeleted { get; set; }
        public List<UserRatingViewModel> Ratings { get; set; }
    }
}
