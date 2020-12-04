using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? UnitId { get; set; }
        public long? CategoryId { get; set; }
        public long? SubCategoryId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public string ProductCode { get; set; }
        public string UnitType { get; set; }
    }
}
