using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Store Name")]
        public string StoreName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Phone]
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DisplayName("Create Date")]
        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [MaxLength(150)]
        public string Slogan { get; set; }

        [DisplayName("Ship Fee")]
        [DataType(DataType.Currency)]
        public float ShipFee { get; set; }

        [ScaffoldColumn(false)]
        public int TotalFollowers { get; set; }

        [ScaffoldColumn(false)]
        public int TotalFollowings { get; set; }

        public virtual int? OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual UserProfile Owner { get; set; }

        public virtual int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual StoreStatus Status { get; set; }

        public virtual int? CoverImageId { get; set; }
        [ForeignKey("CoverImageId")]
        public virtual Image CoverImage { get; set; }

        public virtual int? ProfileImageId { get; set; }
        [ForeignKey("ProfileImageId")]
        public virtual Image ProfileImage { get; set; }

        public virtual int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Follow> Follows { get; set; }

        // Message from Admin for sending mail about status
        public virtual ICollection<Message> Messages { get; set; }
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