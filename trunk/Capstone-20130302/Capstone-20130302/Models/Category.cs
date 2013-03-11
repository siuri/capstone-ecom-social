using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Capstone_20130302.Models
{
    public class Category
    {
        public Category()
        {
            Templates = new List<Template>();
            Templates.Add(new Template());
            CoverImage = new Image();
        }
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual Category Parent { get; set; }


        public virtual Image CoverImage { get; set; }
        public virtual ICollection<Template> Templates { get; set; }
        public virtual ICollection<Follow> Followings { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

    public class Template
    {
        public int TemplateId { get; set; }
        public string ContentInJson { get; set; }
        public virtual Category Category { get; set; }
    }
}
