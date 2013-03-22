using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Product
    {
        public Product()
        {
            CreateDate = DateTime.Now;
        }
        public int ProductId { get; set; }
        
        [DisplayName("Product Name")]
        [Required]
        public string Name { get; set; }

        
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [ScaffoldColumn(false)]
        public int TotalLikes { get; set; }
        
        [ScaffoldColumn(false)]
        public int TotalComments { get; set; }

        [ScaffoldColumn(false)]
        public int TotalBuy { get; set; }

        public string SpecsInJson { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }

        public virtual int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual ProductStatus Status { get; set; }

        public virtual int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Image> ProductImages { get; set; }

        public virtual int? StoreId { get; set; }
        [ForeignKey("StoreId")]
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