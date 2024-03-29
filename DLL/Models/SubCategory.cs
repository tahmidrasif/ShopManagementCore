﻿using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Product = new HashSet<Product>();
        }

        public long SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? CategoryId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public string SubCategoryCode { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
