using System;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class Image : BaseEntity
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string imgPath { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual Product Product { get; set; }
    }
}
