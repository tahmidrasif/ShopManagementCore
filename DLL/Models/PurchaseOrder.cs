using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
        }

        public long PorderId { get; set; }
        public string PorderCode { get; set; }
        public string OrderType { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public long? VendorId { get; set; }
        public bool? IsMasterInventoryOrder { get; set; }
        public long? BranchId { get; set; }
        public long? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public decimal? SubTotal { get; set; }
        public bool? IsVatIncluded { get; set; }
        public decimal? VatPercent { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal? TotalOtherCharge { get; set; }
        public decimal? TotalDeliveryCharge { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalAdvance { get; set; }
        public decimal? TotalDue { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? AdditionalDiscount { get; set; }

        public virtual ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    }
}
