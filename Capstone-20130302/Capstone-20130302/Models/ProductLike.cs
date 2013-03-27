using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class ProductLike
    {
        public int ProductLikeId { get; set; }

        public virtual int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; }

        public virtual int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product{ get; set; }
    }
}