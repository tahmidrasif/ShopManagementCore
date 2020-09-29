using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class Enumaration
    {
        public long EnumId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeDecscription { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
