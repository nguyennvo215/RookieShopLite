using RookieShopLite.Model;
using System.Collections.Generic;

namespace RookieShopLite.ViewModel
{
    public class RenderIndexViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public string SearchString { get; set; }
    }
}
