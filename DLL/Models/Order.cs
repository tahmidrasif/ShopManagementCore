using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
            Payment = new HashSet<Payment>();
        }

        public long OrderId { get; set; }
        public string OrderCode { get; set; }
        public string OrderType { get; set; }
        public DateTime? OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public int? DeliverDue { get; set; }
        public long? VendorId { get; set; }
        public long? CustomerId { get; set; }
        public long? BranchId { get; set; }
        public long? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsVatIncluded { get; set; }
        public decimal? VatPercent { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal? OtherCharge { get; set; }
        public decimal? DeliveryCharge { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? SubTotal { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
