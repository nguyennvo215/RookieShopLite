using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.ViewModel
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CartProductViewModel> ProductLists { get; set; }
    }
}
