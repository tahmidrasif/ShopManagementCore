using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModel.Category
{
    public class CategoryViewModel
    {
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CategoryCode { get; set; }
        //public string CreatedBy { get;  }
        //public DateTime CreatedOn { get;  }
        //public string UpdatedBy { get; }
        //public DateTime UpdatedOn { get; }
    }
}
