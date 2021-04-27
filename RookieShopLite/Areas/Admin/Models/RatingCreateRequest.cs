using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.Models
{
    public class RatingCreateRequest
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public double RatingNumber { get; set; }
        public bool isRated { get; set; }
    }
}
