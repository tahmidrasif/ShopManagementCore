using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class ALedgerEntry
    {
        public long LedgerEntryId { get; set; }
        public long MtranId { get; set; }
        public long AccountId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long Status { get; set; }
        public bool? IsActive { get; set; }
    }
}
