using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Moonlimit.DroneAPI.Entity.Repository
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
        Task<T> GetOne(Expression<Func<T, bool>> predicate);
        Task Insert(T entity);
        void Delete(T entity);
        Task Delete(object id);
        Task Update(object id, T entity);
        Task<List<T>> READbyStoredProcedure(string sql, NpgsqlParameter[] parameters);
        Task<int> CUDbyStoredProcedure(string sql, NpgsqlParameter[] parameters);
    }
}
