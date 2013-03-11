using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Order
    {
        public Order()
        {
            OrderDate = DateTime.Now;
            IsUsedAsShipping = true;
            Status = new OrderStatus();
            BillingAddress = new Address();
            ShippingAddress = new Address();
            OrderDetails = new List<OrderDetail>();
            OrderDetails.Add(new OrderDetail());
        }
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Total Payment")]
        [DataType(DataType.Currency)]
        public float TotalPayment { get; set; }

        [DisplayName("Billing Name or Company")]
        [Required]
        public string BillingName { get; set; }

        [DisplayName("Billing Address")]
        [Required]
        public virtual Address BillingAddress { get; set; }
        public bool IsUsedAsShipping { get; set; }

        [DisplayName("Shipping Address")]
        public string ShippingName { get; set; }
        public virtual Address ShippingAddress { get; set; }

        [DisplayName("Order Status")]
        public virtual OrderStatus Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Amount { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Sold Price")]
        public float SoldPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}