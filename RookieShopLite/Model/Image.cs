using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class Image : BaseEntity
    {
        public Image()
        {
            ProductImages = new HashSet<ProductImages>();
        }
        public string imgPath { get; set; }
        public DateTime AddedDate { get; set; }
        public bool isDeleted { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
    }
}
