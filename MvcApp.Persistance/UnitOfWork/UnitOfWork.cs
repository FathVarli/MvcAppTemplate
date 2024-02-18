﻿using Microsoft.EntityFrameworkCore.Storage;
using MvcApp.Domain.Entities.Abstract;
using MvcApp.Infrastructure.Context;
using MvcApp.Infrastructure.Repositories.Base;

namespace MvcApp.Infrastructure.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _projectDbContext;
        private readonly Dictionary<Type, object> _repositories;
        private readonly IDbContextTransaction _transaction;

        public UnitOfWork(AppDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
            _transaction = _projectDbContext.Database.BeginTransaction();
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity, TPrimaryKey> GetRepository<TEntity, TPrimaryKey>()
            where TEntity : class, IEntity, new()
            where TPrimaryKey : IEquatable<TPrimaryKey>
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
                return (IRepository<TEntity, TPrimaryKey>)_repositories[typeof(TEntity)];

            var repository = new Repository<TEntity, TPrimaryKey>(_projectDbContext);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public int Complete()
        {
            try
            {
                _transaction.Commit();
                return _projectDbContext.SaveChanges();
            }
            catch (Exception)
            {
                RollBack();
                _transaction.Dispose();
                return 0;
            }
        }

        public async Task<int> CompleteAsync()
        {
            try
            {
                await _transaction.CommitAsync();
                return await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                await RollBackAsync();
                await _transaction.DisposeAsync();
                return 0;
            }
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }

        public async Task RollBackAsync()
        {
            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing) _projectDbContext.Dispose();
        }
    }
}