using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            CartProducts = new HashSet<CartProduct>();
        }
        [Required]
        public string UserId { get; set; }
        public DateTime AddedDate { get; set; }
        public bool isCheckedOut { get; set; }
        public IdentityUser user { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
