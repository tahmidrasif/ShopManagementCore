using DLL.Context;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Repository
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
    }

    public class OrderRepository:BaseRepository<Order>,IOrderRepository
    {
      
        private ShopDBEntities _context;
        public OrderRepository(ShopDBEntities context) : base(context)
        {
            _context = context;
        }
    }
}
