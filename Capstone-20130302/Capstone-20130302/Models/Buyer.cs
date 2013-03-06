using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Capstone_20130302.Models
{
    public class Buyer
    {
        public int BuyerId { get; set; }
        public string DisplayName { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public int TotalFollowers { get; set; }
        public int TotalFollowings { get; set; }

        public virtual UserProfile User { get; set; }
        public virtual Image ProfileImage { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
