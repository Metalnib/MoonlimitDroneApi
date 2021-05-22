using Microsoft.EntityFrameworkCore;
using Moonlimit.DroneAPI.Entity.Context;
using Moonlimit.DroneAPI.Entity.UnitofWork;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Moonlimit.DroneAPI.Entity.Repository
{
    /// <summary>
    /// General repository class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>();
        }
        
        public IQueryable<T> GetAllQueryable()
        {
            return _unitOfWork.Context.Set<T>().AsQueryable();
        }
        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable<T>();
        }
        
        public IQueryable<T> GetQueryable(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsQueryable<T>();
        }
        
        public T GetOne(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).FirstOrDefault();
        }
        public void Insert(T entity)
        {
            if (entity == default) return;
            if (entity.Id <= 0) entity.Id = _unitOfWork.Generator.CreateId();
            _unitOfWork.Context.Set<T>().Add(entity);
        }
        public void Update(object id, T entity)
        {
            if (entity != null)
            {
                //T entitytoUpdate = _unitOfWork.Context.Set<T>().Find(id);
                //if (entitytoUpdate != null)
                //	_unitOfWork.Context.Entry(entitytoUpdate).CurrentValues.SetValues(entity);
                _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            }
        }
        public void Delete(object id)
        {
            T entity = _unitOfWork.Context.Set<T>().Find(id);
            Delete(entity);
        }
        public void Delete(T entity)
        {
            if (entity != null) _unitOfWork.Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> READbyStoredProcedure(string sql, NpgsqlParameter[] parameters)
        {
            return _unitOfWork.Context.Set<T>().FromSqlRaw(sql, parameters).ToListAsync().GetAwaiter().GetResult(); ;
        }

        public int CUDbyStoredProcedure(string sql, NpgsqlParameter[] parameters)
        {
            return _unitOfWork.Context.Database.ExecuteSqlRaw(sql, parameters);
        }

    }


}
