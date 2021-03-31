using System;

namespace RookieShopLite.Model
{
    public class RetailDetail : BaseEntity
    {
        public int CartId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime AddedDate { get; set; }
        public bool isPaid { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
