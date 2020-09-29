using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request
{
    public class CategoryInsertRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CategoryCode { get; set; }
    }
}
