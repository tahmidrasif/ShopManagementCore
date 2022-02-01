using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class AAccount
    {
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long Status { get; set; }
        public bool? IsActive { get; set; }
    }
}
