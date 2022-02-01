using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class VwProduct
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public long? UnitId { get; set; }
        public string UnitName { get; set; }
        public long? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public decimal? SaleUnitPrice { get; set; }
        public decimal? SaleVat { get; set; }
        public decimal? SaleOtherCharge { get; set; }
        public decimal? SaleTotalPrice { get; set; }
        public decimal? SaleDiscount { get; set; }
        public decimal? AvaliableQty { get; set; }
        public bool? IsActive { get; set; }
    }
}
