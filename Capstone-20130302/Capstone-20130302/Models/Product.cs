using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }
        public int TotalBuy { get; set; }
        public string SpecsInJson { get; set; }
        
        public DateTime CreateDate { get; set; }

        public virtual ProductStatus Status { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Image> ProductImages { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<UserProfile> Likers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public class ProductStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}