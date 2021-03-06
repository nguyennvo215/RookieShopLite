using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public string imgPath { get; set; }
        public DateTime AddedDate { get; set; }
        public bool isDeleted { get; set; }
        public virtual Product Product { get; set; }
    }
}
