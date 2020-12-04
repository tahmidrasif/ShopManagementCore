using DLL.Context;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Repository
{
    public interface IUnitRepository:IBaseRepository<Unit>
    {

    }

    public class UnitRepository:BaseRepository<Unit>,IUnitRepository
    {
        private ShopDBEntities _context;
        public UnitRepository(ShopDBEntities context) : base(context)
        {
            _context = context;
        }
        
    }
}
