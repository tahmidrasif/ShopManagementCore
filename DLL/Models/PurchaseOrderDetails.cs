using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class PurchaseOrderDetails
    {
        public long PorderDetailsId { get; set; }
        public long? PorderId { get; set; }
        public long? ProductId { get; set; }
        public decimal? Quantity { get; set; }
        public long? UnitId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalUnitPrice { get; set; }
        public long? DiscountType { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? TotalDiscount { get; set; }
        public bool? IsVatIncluded { get; set; }
        public decimal? VatPercent { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal? OtherCharge { get; set; }
        public decimal? SubTotal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual PurchaseOrder Porder { get; set; }
        public virtual Product Product { get; set; }
    }
}
