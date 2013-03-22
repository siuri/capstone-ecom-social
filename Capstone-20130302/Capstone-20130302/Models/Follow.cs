using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Follow
    {
        public int FollowId { get; set; }

        public virtual int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; }

        public virtual int? FollowedUserId { get; set; }
        [ForeignKey("FollowedUserId")]
        public virtual UserProfile FollowedUser { get; set; }

        public virtual int? StoreId { get; set; }
        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }

        public virtual int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}