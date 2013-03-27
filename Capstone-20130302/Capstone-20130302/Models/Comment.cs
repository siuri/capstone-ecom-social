using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Capstone_20130302.Models
{
    public class Comment
    {
        public Comment()
        {
            CreateDate = DateTime.Now;
        }
        public int CommentId { get; set; }

        [DisplayName("Product Name")]
        [Required]
        public string CommentContent { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; }

        public virtual int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
