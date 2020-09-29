using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class StockLog
    {
        public long StockLogId { get; set; }
        public long? StockId { get; set; }
        public DateTime? OperationDate { get; set; }
        public long? BranchId { get; set; }
        public long? UnitId { get; set; }
        public long? OperationType { get; set; }
        public long? ActionType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
