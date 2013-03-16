using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public virtual UserProfile User { get; set; }
        public virtual Store Store { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
    }
}