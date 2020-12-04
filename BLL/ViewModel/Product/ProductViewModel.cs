using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModel.Product
{
    public class ProductViewModel
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public long UnitID { get; set; }
        public string UnitName { get; set; }
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        public long SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public decimal SaleUnitPrice { get; set; }
        public decimal SaleVat { get; set; }
        public decimal SaleOtherCharge { get; set; }
        public decimal SaleTotalPrice { get; set; }
        public decimal SaleDiscount { get; set; }
        public decimal AvaliableQty { get; set; }

        
    }
}
