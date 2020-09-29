using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class MasterInventoryLog
    {
        public long MinventoryLogId { get; set; }
        public long? MinventoryId { get; set; }
        public long? ProductId { get; set; }
        public long? UnitId { get; set; }
        public long? Quantity { get; set; }
        public DateTime? OperationDate { get; set; }
        public long? OperationType { get; set; }
        public long? ActionType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public string Remarks { get; set; }
    }
}
