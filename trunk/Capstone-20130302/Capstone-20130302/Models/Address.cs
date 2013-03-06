﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public bool IsSetAsDefault { get; set; }
    }
}