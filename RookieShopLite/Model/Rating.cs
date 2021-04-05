using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Model
{
    public class Rating : BaseEntity
    {
        public double Rate { get; set; }
        public int ProductId { get; set; }
    }
}
