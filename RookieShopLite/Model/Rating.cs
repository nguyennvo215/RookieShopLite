namespace RookieShopLite.Model
{
    public class Rating : BaseEntity
    {
        public double Rate { get; set; }
        public int ProductId { get; set; }
    }
}
