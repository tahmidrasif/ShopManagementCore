using DLL.Context;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL.Repository
{
    public interface ISubCategoryRepository : IBaseRepository<SubCategory>
    {
        public List<SubCategory> GetAllSubCategoryByCategoryId(long categoryId);
    }

    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        private ShopDBEntities _context;
        public SubCategoryRepository(ShopDBEntities context) : base(context)
        {
            _context = context;
        }

        public List<SubCategory> GetAllSubCategoryByCategoryId(long categoryId)
        {
            return _context.SubCategory.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
