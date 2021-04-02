using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Model
{
    public class ProductImages
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
