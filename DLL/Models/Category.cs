using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
            SubCategory = new HashSet<SubCategory>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public string CategoryCode { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
