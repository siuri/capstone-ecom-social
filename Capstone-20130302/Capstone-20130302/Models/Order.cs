using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone_20130302.Models
{
    public class Order
    {
        public Order()
        {
            IsUsedAsShipping = true;
        }
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Order Date")]
        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Total Payment")]
        [DataType(DataType.Currency)]
        public float TotalPayment { get; set; }

        [DisplayName("Billing Name or Company")]
        [Required]
        public string BillingName { get; set; }


        public virtual int? BillingAddressId { get; set; }
        [Required]
        [ForeignKey("BillingAddressId")]
        public virtual Address BillingAddress { get; set; }

        public bool IsUsedAsShipping { get; set; }


        [DisplayName("Shipping Name")]
        public string ShippingName { get; set; }

        public virtual int? ShippingAddressId { get; set; }
        [ForeignKey("ShippingAddressId")]
        public virtual Address ShippingAddress { get; set; }

        public virtual int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        [DisplayName("Order Status")]
        public virtual OrderStatus Status { get; set; }


        public virtual int? UserId { get; set; }
        [ForeignKey("UserId")]
        [DisplayName("UserId")]
        public virtual UserProfile Users { get; set; }

        public virtual int? StoreId { get; set; }
        [ForeignKey("StoreId")]
        public virtual Store Stores { get; set; }
       
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

        public virtual int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public virtual int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}