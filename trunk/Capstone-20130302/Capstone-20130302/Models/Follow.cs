using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Follow
    {
        public int FollowId { get; set; }
        public virtual UserProfile User { get; set; }
        public virtual UserProfile FollowedUser { get; set; }
        public virtual Store Store { get; set; }
        public virtual Category Category { get; set; }
    }
}