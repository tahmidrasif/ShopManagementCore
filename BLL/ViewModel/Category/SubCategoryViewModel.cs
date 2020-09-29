using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModel.Category
{
    public class SubCategoryViewModel
    {
        public long SubCategoryId { get; set; }
        public string Name { get; set; }
        public string SubCategoryCode { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
