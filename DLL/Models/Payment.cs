using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class Payment
    {
        public long PaymentId { get; set; }
        public long? PaymentType { get; set; }
        public long? PaymentMethod { get; set; }
        public long? OrderId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public bool? IsDue { get; set; }
        public decimal? DueAmount { get; set; }
        public decimal? ChangeAmount { get; set; }
        public string CardNo { get; set; }
        public string ChqueNo { get; set; }
        public bool? IsChequeCleared { get; set; }
        public string CrDr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Order Order { get; set; }
    }
}
