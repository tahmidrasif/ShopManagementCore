using DLL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DLL.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        //Entity
        void Add(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null);
        T GetSingle(Expression<Func<T, bool>> expression = null);
        void Delete(T entity);
        object GetDropdownList(string label, string value, T entity);
        
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ShopDBEntities _context;


        public BaseRepository(ShopDBEntities context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return _context.Set<T>().ToList();

            }
            return _context.Set<T>().Where(expression).ToList();
        }
        public T GetSingle(Expression<Func<T, bool>> expression = null)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public object GetDropdownList(string label, string value, T entity)
        {
            throw new NotImplementedException();
        }

        //public int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        //{
        //    if (_context.Database.GetDbConnection().State == ConnectionState.Closed)
        //    {
        //        _context.Database.OpenConnection();
        //    }

        //    var command = _context.Database.GetDbConnection().CreateCommand();
        //    command.CommandText = commandText;
        //    command.CommandType = commandType;

        //    if (parameters != null)
        //    {
        //        foreach (var parameter in parameters)
        //        {
        //            command.Parameters.Add(parameter);
        //        }
        //    }

        //    int count = command.ExecuteNonQuery();
        //    return count;
        //}

        //public DataTable ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        //{
        //    if (_context.Database.GetDbConnection().State == ConnectionState.Closed)
        //    {
        //        _context.Database.OpenConnection();
        //    }

        //    var command = _context.Database.GetDbConnection().CreateCommand();
        //    command.CommandText = commandText;
        //    command.CommandType = commandType;

        //    if (parameters != null)
        //    {
        //        foreach (var parameter in parameters)
        //        {
        //            command.Parameters.Add(parameter);
        //        }
        //    }
        //    using (var reader = command.ExecuteReader())
        //    {
        //        DataTable dt = new DataTable();
        //        dt.Load(reader);
        //        return dt;
        //    }
        //}

        
    }
}
