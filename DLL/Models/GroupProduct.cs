using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class GroupProduct
    {
        public long ProductGroupId { get; set; }
        public long? MasterProductId { get; set; }
        public long? ChildProductId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
