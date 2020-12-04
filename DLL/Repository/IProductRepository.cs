using DLL.Context;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        ProductPrice GetProductPriceById(long productId);
        Stock GetProductStock(long productId);
    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private ShopDBEntities _context;
        public ProductRepository(ShopDBEntities context) : base(context)
        {
            _context = context;
        }

        public ProductPrice GetProductPriceById(long productId)
        {
            return _context.ProductPrice.FirstOrDefault(x => x.ProductId == productId);
        }

        public Stock GetProductStock(long productId)
        {
            return _context.Stock.FirstOrDefault(x => x.ProductId == productId);
        }
    }
}
