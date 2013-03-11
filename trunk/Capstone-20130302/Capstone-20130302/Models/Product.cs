using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Product
    {
        public Product()
        {
            Name = "Untitled Product";
            Description = "Describe your Product here.";
            SpecsInJson = "";
            Status = new ProductStatus();
            Category = new Category();
            ProductImages = new List<Image>();
            ProductImages.Add(new Image());
            ProductImages.Add(new Image());
            ProductImages.Add(new Image());
            CreateDate = DateTime.Now;
        }
        public int ProductId { get; set; }
        
        [DisplayName("Product Name")]
        [Required]
        public string Name { get; set; }

        
        [DisplayName("Description")]
        [Required]
        [DataType(DataType.MultilineText)]
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