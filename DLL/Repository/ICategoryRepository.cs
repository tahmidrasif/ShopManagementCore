using DLL.Context;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DLL.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {

        public List<SubCategory> GetAllSubCategory(Expression<Func<SubCategory, bool>> expression = null);
        public SubCategory GetSingleSubCategory(Expression<Func<SubCategory, bool>> expression = null);
        void AddSubCategory(SubCategory entity);
        void UpdateSubCategory(SubCategory entity);
        void Delete(SubCategory entity);
    }

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private ShopDBEntities _context;
        public CategoryRepository(ShopDBEntities context) : base(context)
        {
            _context = context;
        }

        public void AddSubCategory(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public List<SubCategory> GetAllSubCategory(Expression<Func<SubCategory, bool>> expression = null)
        {
            if (expression == null)
                return _context.SubCategory.Where(x => x.IsActive == true).ToList();

            return  _context.SubCategory.Where(x => x.IsActive == true).Where(expression).ToList();
        }

        public SubCategory GetSingleSubCategory(Expression<Func<SubCategory, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubCategory(SubCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
