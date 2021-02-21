using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class Unit
    {
        public Unit()
        {
            OrderDetails = new HashSet<OrderDetails>();
            Product = new HashSet<Product>();
        }

        public long UnitId { get; set; }
        public string UnitName { get; set; }
        public string UnitType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
