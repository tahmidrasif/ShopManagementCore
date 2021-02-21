using Dapper;
using DLL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DLL.Repository
{
    public interface IQueryRepository
    {
        // 1. SqlCommand approach
        int ExecuteNonQuerySql(string commandText, CommandType commandType, SqlParameter[] parameters = null);
        // 2. SqlQuery approach
        DataTable ExecuteReaderSql(string commandText, CommandType commandType, SqlParameter[] parameters = null);
        // 3. SqlCommand approach By Dapper
        int ExecuteNonQueryDapper<T>(string query, DynamicParameters parms, CommandType commandType);
        // 2. SqlQuery approach By Dapper
        List<T> ExecuteReaderDapper<T>(string query, DynamicParameters parms, CommandType commandType);

    }

    public class QueryRepository : IQueryRepository
    {


        private ShopDBEntities _context;
        private IConfiguration _config;
        //private IDbConnection _db;
        private int result = 0;

        public QueryRepository(ShopDBEntities context,IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
            //_db= new SqlConnection(_config.GetConnectionString("ShopDbConnection"));

        }



        public int ExecuteNonQueryDapper<T>(string query, DynamicParameters parms, CommandType commandType)
        {

            using IDbConnection db = new SqlConnection(_config.GetConnectionString("ShopDbConnection"));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                //using var tran = db.BeginTransaction();

                result = db.Query<int>(query, parms, commandType: commandType).FirstOrDefault();
                //result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                //tran.Commit();

            }
            catch (Exception ex)
            {
                //tran.RollBack();
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return result;
        }

        
        public List<T> ExecuteReaderDapper<T>(string query, DynamicParameters parms, CommandType commandType)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString("ShopDbConnection"));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<T>(query, parms, commandType: commandType).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }

        public int ExecuteNonQuerySql(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (_context.Database.GetDbConnection().State == ConnectionState.Closed)
            {
                _context.Database.OpenConnection();
            }

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            int count = command.ExecuteNonQuery();
            return count;
        }

        public DataTable ExecuteReaderSql(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (_context.Database.GetDbConnection().State == ConnectionState.Closed)
            {
                _context.Database.OpenConnection();
            }

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            using (var reader = command.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
    }
}
