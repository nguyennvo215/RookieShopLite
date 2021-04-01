using System;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class Image : BaseEntity
    {
        public int ProductId { get; set; }
        public string imgPath { get; set; }
        public DateTime AddedDate { get; set; }
        public bool isDeleted { get; set; }
        public virtual Product Product { get; set; }
    }
}
