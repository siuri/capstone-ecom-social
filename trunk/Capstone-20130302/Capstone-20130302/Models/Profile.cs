using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Capstone_20130302.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Phone]
        [DisplayName("Phone Number")]
        public string ContactNumber { get; set; }

        [ScaffoldColumn(false)]
        public int TotalFollowers { get; set; }
        [ScaffoldColumn(false)]
        public int TotalFollowings { get; set; }

        public virtual int? ProfileImageId { get; set; }
        [ForeignKey("ProfileImageId")]
        public virtual Image ProfileImage { get; set; }

        public virtual int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
    }
}
