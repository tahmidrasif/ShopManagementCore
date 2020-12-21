using Dapper;
using DLL.Context;
using DLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DLL.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {

        public List<SubCategory> GetAllSubCategory(Expression<Func<SubCategory, bool>> expression = null);
        public int InsertCategory();

    }

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private ShopDBEntities _context;
        private IQueryRepository _queryRepostiory;
        private IConfiguration _configuration;

        public CategoryRepository(ShopDBEntities context,IQueryRepository queryRepository) : base(context)
        {
            _context = context;
            _queryRepostiory = queryRepository;
        }



        public List<SubCategory> GetAllSubCategory(Expression<Func<SubCategory, bool>> expression = null)
        {
            if (expression == null)
                return _context.SubCategory.Where(x => x.IsActive == true).ToList();

            return _context.SubCategory.Where(x => x.IsActive == true).Where(expression).ToList();
        }

        public int InsertCategory()
        {

            //string query = @"Insert Into Category (CategoryName,Description,CategoryCode)
            //                Values (@CategoryName,@Description,@CategoryCode);";
            ////SELECT CAST(SCOPE_IDENTITY() as int);";

            string query = @"Select p.ProductCode,p.Name,c.CategoryName,c.CategoryCode,s.Name as SubcategoryName,s.SubCategoryCode 
                            from Product p 
                            inner join Category   c on p.CategoryID=c.CategoryID
                            inner join SubCategory s on p.SubCategoryID=s.SubCategoryID";

            //DynamicParameters parameter = new DynamicParameters();
            //Random random = new Random();
            //var rand=random.Next(0, 100);
            //parameter.Add("@CategoryName", "Pakka "+rand, DbType.String, ParameterDirection.Input);
            //parameter.Add("@Description", "Paka Bazar "+rand, DbType.String, ParameterDirection.Input);
            //parameter.Add("@CategoryCode", rand.ToString().PadLeft(4, '0'), DbType.String, ParameterDirection.Input);

            var result = _queryRepostiory.ExecuteReaderSql(query,CommandType.Text,null);

            
            //return result;
            return 0;
        }
    }
}

public class producttestvm
{
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public string CategoryCode { get; set; }
    public string SubcategoryName { get; set; }
    public string SubCategoryCode { get; set; }
}
