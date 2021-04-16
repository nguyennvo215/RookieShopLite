using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class UserRating : BaseEntity
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public bool isRated { get; set; }
        [Range(0.0, 10.0, ErrorMessage ="The field {0} must be in range from 0 to 10")]
        public double  RatingNumber { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
