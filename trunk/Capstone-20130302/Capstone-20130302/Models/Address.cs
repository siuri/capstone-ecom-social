using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [DisplayName("Number")]
        public string Number { get; set; }

        [DisplayName("Street")]
        public string Street { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State or Province")]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        public string Zipcode { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Is set as Default")]
        public bool IsSetAsDefault { get; set; }
    }
}