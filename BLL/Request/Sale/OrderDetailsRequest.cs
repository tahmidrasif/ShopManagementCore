using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request.Sale
{
    public class OrderDetailsRequest
    {
        public long ProductID { get; set; }
        public decimal Quantity { get; set; }
        public long UnitID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Vat { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
    }
}
