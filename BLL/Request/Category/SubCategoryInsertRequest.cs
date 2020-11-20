using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request.Category
{
    public class SubCategoryInsertRequest
    {
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public string SubCategoryCode { get; set; }
        public long CategoryID { get; set; }
    }
}
