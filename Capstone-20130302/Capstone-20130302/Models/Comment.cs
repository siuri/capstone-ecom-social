using System;
using System.Collections.Generic;
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
        public string CommentContent { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; }
    }
}
