using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Areas.Admin.Models
{
    public class CategoryCreateRequest
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
