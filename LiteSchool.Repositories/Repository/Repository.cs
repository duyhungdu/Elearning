using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using LiteSchool.Entities;
using LiteSchool.Core.Queries;
using LiteSchool.Core.Messages;
using LiteSchool.Core.IRepository;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using LiteSchool.Library.RepoWrapper;

namespace LiteSchool.Repositories
{
    /// <summary>
    /// Base repository that wraps the Dapper Micro ORM
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// For more information regarding Dapper see: http://code.google.com/p/dapper-dot-net/
    /// </remarks>
    public abstract class Repository<TId, TEntity,TDto> : IRepository<TId, TEntity, TDto> where TEntity : BaseEntity<TId>
    {
        /// <summary>
        /// The _table name
        /// </summary>
        protected readonly string _tableName;
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["LiteSchoolConnection"].ConnectionString);
            }
        }
        
        public Repository()
        {
            _tableName = SimpleCRUD.GetTableName(typeof(TEntity));
        }
        /// <summary>
        /// Mapping the object to the insert/update columns.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The parameters with values.</returns>
        /// <remarks>In the default case, we take the object as is with no custom mapping.</remarks>
        internal virtual dynamic Mapping(TEntity item)
        {
            return item;
        }

        public virtual TEntity Add(TEntity entity)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    entity.Id = cn.Insert<TId, TEntity>(entity);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual void Edit(TEntity entity)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    cn.Update(entity);
                }
            }
            catch
            {
                throw;
            }
        }

        public virtual void Delete(TId id)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    cn.Execute("DELETE FROM " + _tableName + " WHERE Id=@Id", new { Id = id });
                }
            }
            catch
            {
                throw;
            }
        }

        public virtual void Delete(List<TId> ids)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    var param = string.Join(",", ids);
                    var sql = string.Format("DELETE FROM " + _tableName + " WHERE Id IN (select * from fnSplitString('{0}',','))", param);
                    cn.Execute(sql);
                }
            }
            catch
            {
                throw;
            }
        }

        public IList<TEntity> FindAll()
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    IEnumerable<TEntity> list = default(IEnumerable<TEntity>);
                    list = cn.Query<TEntity>("SELECT * FROM " + _tableName);
                    return list.ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        public virtual TEntity FindById(TId id)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    TEntity item = default(TEntity);
                    item = cn.Query<TEntity>("SELECT * FROM " + _tableName + " WHERE Id=@Id", new { Id = id }).SingleOrDefault();
                    return item;
                }
            }
            catch
            {
                throw;
            }
        }

        public virtual IList<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    IEnumerable<TEntity> items = null;
                    // extract the dynamic sql query and parameters from predicate
                    QueryResult result = DynamicQuery.GetDynamicQuery(_tableName, predicate);
                    items = cn.Query<TEntity>(result.Sql, (object)result.Param);
                    return items.ToList();
                }
            }
            catch
            {
                throw;
            }
        }

































        /// <summary>
        /// Query
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="type">M</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Query(string sql, object param = null, CommandType type = CommandType.StoredProcedure)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return cn.Query<TEntity>(sql, param, commandType: type);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Query trả về kiểu tùy ý
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual IEnumerable<K> Query<K>(string sql, object param = null, CommandType type = CommandType.StoredProcedure)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return cn.Query<K>(sql, param, commandType: type);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual K ExcuteScalar<K>(string sql, object param = null, CommandType type = CommandType.StoredProcedure)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return cn.Query<K>(sql, param, commandType: type).Single();
                }
            }
            catch
            {
                throw;
            }
        }

        public virtual K ExcuteScalar<K>(string sql, object param, SqlConnection cn, SqlTransaction tran)
        {
            return cn.Query<K>(sql, param, transaction: tran, commandType: CommandType.StoredProcedure).Single();
        }

        public virtual void ExcuteNonQuery(string sql, object param = null, CommandType type = CommandType.StoredProcedure)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    cn.Execute(sql, param, commandType: type);
                }
            }
            catch
            {
                throw;
            }
        }

        public virtual void ExcuteNonQueryWithTransaction(string sql, object param = null, CommandType type = CommandType.StoredProcedure)
        {
            using (var cn = Connection)
            using (var transaction = cn.BeginTransaction())
            {
                cn.Open();
                cn.Execute(sql, param, commandType: type);
                transaction.Commit();
            }
        }

        public virtual void TruncateTable()
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    var sql = "truncate TABLE " + _tableName;
                    cn.Execute(sql);
                }
            }
            catch
            {
                throw;
            }
        }


    }
}
