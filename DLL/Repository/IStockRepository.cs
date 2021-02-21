using DLL.Context;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Repository
{
    public interface IStockRepository:IBaseRepository<Stock>
    {
    }
    public class StockRepository:BaseRepository<Stock>,IStockRepository
    {
        private readonly ShopDBEntities _context;   
        public StockRepository(ShopDBEntities context):base(context)
        {
            _context = context;
        }
    }
}
