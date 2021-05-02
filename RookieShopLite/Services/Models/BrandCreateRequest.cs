using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Areas.Admin.Models
{
    public class BrandCreateRequest
    {
        [Required]
        public string BrandName { get; set; }
    }
}
