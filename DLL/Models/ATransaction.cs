using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class ATransaction
    {
        public long ATranId { get; set; }
        public long BranchId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string VoucherNumber { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public long Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorizedBy { get; set; }
        public DateTime? AuthorizedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
