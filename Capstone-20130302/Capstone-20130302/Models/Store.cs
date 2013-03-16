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
        public Store()
        {
            StoreName = "Untitled Store Name";
            Description = "Describe your Store here.";
            CreateDate = DateTime.Now;
            Slogan = "Describe your Slogan here.";
            Status = new StoreStatus();
            CoverImage = new Image();
            ProfileImage = new Image();
            Addresses = new List<Address>();
            Addresses.Add(new Address());
        }
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

        public virtual UserProfile Owner { get; set; }
        public virtual StoreStatus Status { get; set; }

        [DisplayName("Cover Image")]
        public virtual Image CoverImage { get; set; }

        [DisplayName("Profile Image")]
        public virtual Image ProfileImage { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

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