using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request.Sale
{
    public class PaymentRequest
    {
        public decimal SubTotal { get; set; }
        public decimal TotalVat { get; set; }
        public decimal OtherCharge { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal GrandTotal { get; set; }

        public IEnumerable<OrderDetailsRequest> OrderDetailsList { get; set; }

        public long PaymentType { get; set; }
        public long PaymentMethod { get; set; }
        public string CardNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public bool IsDue { get; set; }
        public decimal DueAmount { get; set; }
        public decimal ChangeAmount { get; set; }

    }
}
