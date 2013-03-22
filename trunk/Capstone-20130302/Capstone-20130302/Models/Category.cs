using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Capstone_20130302.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        
        [Required]
        [Display(Name = "Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual int? ParentId { get; set; }
        
        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }

        public virtual int? CoverImageId { get; set; }
        [ForeignKey("CoverImageId")]
        public virtual Image CoverImage { get; set; }

        public virtual int? TemplateId { get; set; }
        [ForeignKey("TemplateId")]
        public virtual Template Template { get; set; }

        public virtual ICollection<Follow> Followings { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }



    public class Template
    {
        public int TemplateId { get; set; }
        public string ContentInJson { get; set; }
    }

    public class CommodityCategoryMap : EntityTypeConfiguration<Category>
    {
        public CommodityCategoryMap()
        {
            HasKey(x => x.CategoryId);

            Property(x => x.CategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasOptional(x => x.Parent)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.ParentId)
                .WillCascadeOnDelete(false);
        }
    }
}
