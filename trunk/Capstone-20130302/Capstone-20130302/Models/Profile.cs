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
        public Profile()
        {
            ProfileImage = new Image();
            Addresses = new List<Address>();
            Addresses.Add(new Address());
        }
        public int ProfileId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2010",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Phone]
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }

        [ScaffoldColumn(false)]
        public int TotalFollowers { get; set; }
        [ScaffoldColumn(false)]
        public int TotalFollowings { get; set; }
        
        public virtual Image ProfileImage { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
