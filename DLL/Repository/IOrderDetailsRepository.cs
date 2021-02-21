using DLL.Context;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Repository
{
    public interface IOrderDetailsRepository : IBaseRepository<OrderDetails>
    {
        void AddRange(List<OrderDetails> entities);
    }

    public class OrderDetailsRepository:BaseRepository<OrderDetails>,IOrderDetailsRepository
    {
        private ShopDBEntities _context;
        public OrderDetailsRepository(ShopDBEntities context) : base(context)
        {
            _context = context;
        }

        public void AddRange(List<OrderDetails> entities)
        {
            _context.OrderDetails.AddRange(entities);
        }
    }
}
