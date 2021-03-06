namespace RookieShopLite.Areas.Admin.Models
{
    public class ProductCreateRequest
    {
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductFullDescription { get; set; }
        public decimal ProductPriceNow { get; set; }
        public decimal ProductPriceBefore { get; set; }
        public string ImgPath { get; set; }
    }
}
