﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieShopLite.Model
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Image = new HashSet<Image>();
        }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductFullDescription { get; set; }
        public double ProductPrice { get; set; }
        public double PromotionPrice { get; set; }
        public bool isPublished { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Image> Image { get; set; }
    }
}
