﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.ViewModel
{
    public class UserRatingViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public double Rating { get; set; }
    }
}
