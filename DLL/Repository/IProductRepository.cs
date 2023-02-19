using DLL.Context;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DLL.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        ProductPrice GetProductPriceById(long productId);
        Stock GetProductStock(long productId);
        int UpdateStock(long productId, decimal qty);
        List<VwProduct> GetAllProductVw(int currentPage, int pageSize);
        VwProduct GetProductVwById(long productId);
        int GetCount();
        void InsertProductPrice(ProductPrice productPrice);
        void InsertStock(Stock stock);
    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private ShopDBEntities _context;
        private readonly IQueryRepository _queryRepository;

        public ProductRepository(ShopDBEntities context, IQueryRepository queryRepository) : base(context)
        {
            _context = context;
            _queryRepository = queryRepository;
        }

        
        public ProductPrice GetProductPriceById(long productId)
        {
            return _context.ProductPrice.FirstOrDefault(x => x.ProductId == productId);
        }

        public Stock GetProductStock(long productId)
        {
            return _context.Stock.FirstOrDefault(x => x.ProductId == productId);
        }

        public int UpdateStock(long productId, decimal qty)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                     {
                            new SqlParameter("@ProductId", productId),
                            new SqlParameter("@Qty", qty)
                     };
                return _queryRepository.ExecuteNonQuerySql("SP_UpdateStock", CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
            
        }

        public List<VwProduct> GetAllProductVw(int currentPage, int pageSize)
        {
            return _context.VwProduct.Where(x => x.IsActive==true).Skip(currentPage).Take(pageSize).ToList();
        }

        public VwProduct GetProductVwById(long productId)
        {
            return _context.VwProduct.FirstOrDefault(x => x.IsActive == true && x.ProductId == productId);
        }

        public int GetCount()
        {
            return _context.VwProduct.Count();
        }

        public void InsertProductPrice(ProductPrice productPrice)
        {
            _context.ProductPrice.Add(productPrice);
        }

        public void InsertStock(Stock stock)
        {
            _context.Stock.Add(stock);
        }
    }
}
