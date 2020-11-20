﻿using DLL.Context;
using DLL.Repository;
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
        //End Fields

        void BeginTrnsaction();
        void CommitTransaction();
        void Save();
        void RollbackTransaction();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDBEntities _context;
        
        //All Repository Init
        private ICategoryRepository _categoryRepository;
        private ISubCategoryRepository _subCategoryRepository;
        //All Repository Init

        private bool _disposed = false;

        public UnitOfWork(ShopDBEntities context)
        {
            _context = context;
        }

        //Initialize Repositories

        //public ICategoryRepository CategoryRepository 
        //{
        //    get
        //    {
        //        return _categoryRepository == null ? new CategoryRepository(_context) : _categoryRepository;
        //    }
        //}

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);
        public ISubCategoryRepository SubCategoryRepository => _subCategoryRepository ??= new SubCategoryRepository(_context);



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