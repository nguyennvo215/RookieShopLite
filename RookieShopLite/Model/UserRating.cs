using Microsoft.AspNetCore.Identity;

namespace RookieShopLite.Model
{
    public class UserRating
    {
        public int UserId { get; set; }
        public int RatingId { get; set; }
        public bool isRated { get; set; }
        public double  RatingNumber { get; set; }
        public virtual IdentityUser AspNetUsers { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
