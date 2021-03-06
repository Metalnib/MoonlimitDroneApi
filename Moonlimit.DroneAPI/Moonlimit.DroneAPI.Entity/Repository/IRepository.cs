﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Moonlimit.DroneAPI.Entity.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        T GetOne(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Update(object id, T entity);
        IEnumerable<T> READbyStoredProcedure(string sql, NpgsqlParameter[] parameters);
        int CUDbyStoredProcedure(string sql, NpgsqlParameter[] parameters);
    }
}
