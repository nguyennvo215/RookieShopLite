using RookieShopLite.Model;
using System.Collections.Generic;

namespace RookieShopLite.ViewModel
{
    public class RenderIndexViewModel
    {
        public List<Product> Products { get; set; }
        public string SearchString { get; set; }
    }
}
