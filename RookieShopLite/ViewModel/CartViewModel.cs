using System.Collections.Generic;

namespace RookieShopLite.ViewModel
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartProductViewModel> ProductLists { get; set; }
    }
}
