using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class OrderDetails
    {
        public long OrderDetailsId { get; set; }
        public long? OrderId { get; set; }
        public long? ProductId { get; set; }
        public decimal? Quantity { get; set; }
        public long? UnitId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public long? DiscountType { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? TotalDiscount { get; set; }
        public bool? IsVatIncluded { get; set; }
        public decimal? VatPercent { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal? OtherCharge { get; set; }
        public decimal? SubTotal { get; set; }
        public long? OrderStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
