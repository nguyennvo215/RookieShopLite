using System;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Areas.Admin.Models
{
    public class RatingCreateRequest
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        [Range(0.0, 10.0, ErrorMessage = "The field {0} must be in range from 0 to 10")]
        public int RatingNumber { get; set; }
        public string Content { get; set; }
        public bool isRated { get; set; }
    }
}
