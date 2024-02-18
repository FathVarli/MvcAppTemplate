using MvcApp.Domain.Entities.Abstract;
using MvcApp.Infrastructure.Repositories.Base;

namespace MvcApp.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity, TPrimaryKey> GetRepository<TEntity, TPrimaryKey>()
            where TEntity : class, IEntity, new() where TPrimaryKey : IEquatable<TPrimaryKey>;

        int Complete();

        Task<int> CompleteAsync();

        void RollBack();

        Task RollBackAsync();
    }
}