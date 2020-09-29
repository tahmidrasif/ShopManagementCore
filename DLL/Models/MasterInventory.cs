using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class MasterInventory
    {
        public long MinventoryId { get; set; }
        public long? ProductId { get; set; }
        public long? UnitId { get; set; }
        public decimal? Quantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
