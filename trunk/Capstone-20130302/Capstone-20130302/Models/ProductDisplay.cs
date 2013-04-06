using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class ProductDisplay
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public string Images { get; set; }
    }
}