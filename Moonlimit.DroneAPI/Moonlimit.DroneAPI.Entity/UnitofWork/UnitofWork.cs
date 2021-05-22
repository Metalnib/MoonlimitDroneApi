using Microsoft.EntityFrameworkCore;
using Moonlimit.DroneAPI.Entity.Context;
using Moonlimit.DroneAPI.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdGen;

namespace Moonlimit.DroneAPI.Entity.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : BaseEntity;

        DefaultDbContext Context { get; }
        IdGenerator Generator { get; }
        int Save();
        Task<int> SaveAsync();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
    }

    public class UnitOfWork : IUnitOfWork
    {
        public DefaultDbContext Context { get; }
        public IdGenerator Generator { get; }

        private Dictionary<Type, object> _repositoriesAsync;
        private Dictionary<Type, object> _repositories;
        private bool _disposed;

        public UnitOfWork(DefaultDbContext context, IdGenerator generator)
        {
            Context = context;
            _disposed = false;
            Generator = generator;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(this);
            return (IRepository<TEntity>)_repositories[type];
        }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositoriesAsync = new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!_repositoriesAsync.ContainsKey(type)) _repositoriesAsync[type] = new RepositoryAsync<TEntity>(this);
            return (IRepositoryAsync<TEntity>)_repositoriesAsync[type];
        }

        public int Save()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return -1;
            }
        }
        public async Task<int> SaveAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return -1;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
