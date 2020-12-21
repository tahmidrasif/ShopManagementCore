using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request.Product
{
    public class ProductUpdateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long? UnitId { get; set; }
        public long? CategoryId { get; set; }
        public long? SubCategoryId { get; set; }
        public string ProductCode { get; set; }
    }
}
