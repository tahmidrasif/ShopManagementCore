using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class OrderLog
    {
        public long OrderLogId { get; set; }
        public long? OrderId { get; set; }
        public long? Status { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
