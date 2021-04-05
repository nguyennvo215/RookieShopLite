namespace RookieShopLite.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int MyProperty { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductFullDescription { get; set; }
        public double ProductPriceNow { get; set; }
        public double ProductPriceBefore { get; set; }
        public bool isDeleted { get; set; }
    }
}
