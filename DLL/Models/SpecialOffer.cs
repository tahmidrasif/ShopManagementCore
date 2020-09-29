using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class SpecialOffer
    {
        public long SpecialOfferId { get; set; }
        public long? ProductId { get; set; }
        public string SpecialOfferText { get; set; }
        public DateTime? OfferStartDate { get; set; }
        public DateTime? OfferEndDate { get; set; }
        public bool? IsDiscount { get; set; }
        public long? DiscountType { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? TotalDiscount { get; set; }
        public bool? IsFree { get; set; }
        public bool? IsCashBack { get; set; }
        public long? CashBackType { get; set; }
        public decimal? CashBackPercent { get; set; }
        public decimal? TotalCashBack { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
