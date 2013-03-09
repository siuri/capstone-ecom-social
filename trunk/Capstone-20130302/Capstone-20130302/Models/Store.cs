using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Store
    {
        public int StoreId { get; set; }

        [Required]
        [MaxLength(50)]
        public string StoreName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [MaxLength(25)]
        public string ContactNumber { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [MaxLength(150)]
        public string Slogan { get; set; }

        public float ShipFee { get; set; }

        [ScaffoldColumn(false)]
        public int TotalFollowers { get; set; }

        [ScaffoldColumn(false)]
        public int TotalFollowings { get; set; }

        public virtual UserProfile Owner { get; set; }
        public virtual StoreStatus Status { get; set; }
        public virtual Image CoverImage { get; set; }
        public virtual Image ProfileImage { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Follow> Follows { get; set; }
    }

    public class StoreStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}