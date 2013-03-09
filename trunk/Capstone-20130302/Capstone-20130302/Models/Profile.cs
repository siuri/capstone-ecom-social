using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Phone]
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }

        [Url]
        [DisplayName("Website")]
        public string Website { get; set; }

        [ScaffoldColumn(false)]
        public int TotalFollowers { get; set; }
        [ScaffoldColumn(false)]
        public int TotalFollowings { get; set; }
        public virtual Image ProfileImage { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
