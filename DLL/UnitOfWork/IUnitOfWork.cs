using DLL.Context;
using DLL.Models;
using DLL.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        //Fields
        ICategoryRepository CategoryRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get;  }
        IProductRepository ProductRepository { get; }
        IUnitRepository UnitRepository { get; }
        //End Fields

        void BeginTrnsaction();
        void CommitTransaction();
        void Save();
        void RollbackTransaction();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDBEntities _context;
        private IQueryRepository _queryRepository;

        //All Repository Init
        private ICategoryRepository _categoryRepository;
        private ISubCategoryRepository _subCategoryRepository;
        private IProductRepository _productRepository;
        private IUnitRepository _unitRepository;
        
        //All Repository Init

        private bool _disposed = false;

        public UnitOfWork(ShopDBEntities context,IQueryRepository queryRepository)
        {
            _context = context;
            
            _queryRepository = queryRepository;
        }

        //Initialize Repositories

        //public ICategoryRepository CategoryRepository 
        //{
        //    get
        //    {
        //        return _categoryRepository == null ? new CategoryRepository(_context) : _categoryRepository;
        //    }
        //}

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context, _queryRepository);
        public ISubCategoryRepository SubCategoryRepository => _subCategoryRepository ??= new SubCategoryRepository(_context);
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);
        public IUnitRepository UnitRepository => _unitRepository ??= new UnitRepository(_context);
        //public IQueryRepository QueryRepository => _queryRepository ??= new QueryRepository(_context);
        //End Initialize Repositories

        public void BeginTrnsaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                _context.Dispose();
            }

            _disposed = true;
        }

    }
}

//public interface IResourcePolicy
//{
//    string Version { get; set; }
//}
//class MyResourcePolicy : IResourcePolicy
//{
//    private string version;

//    public string Version
//    {
//        get
//        {
//            return this.version;
//        }
//        set
//        {
//            this.version = value;
//        }
//    }
//}