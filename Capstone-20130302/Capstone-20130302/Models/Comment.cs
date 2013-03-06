using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capstone_20130302.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
