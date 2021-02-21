using DLL.Context;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Repository
{
    public interface IPaymentRepository:IBaseRepository<Payment>
    {
    }

    public class PaymentRepository:BaseRepository<Payment>,IPaymentRepository
    {

        private ShopDBEntities _context;
        public PaymentRepository(ShopDBEntities context) : base(context)
        {
            _context = context;
        }
    }
}
