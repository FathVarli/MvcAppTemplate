using MvcApp.Domain.Entities.Concrete;
using MvcApp.Infrastructure.Repositories.Base;

namespace MvcApp.Infrastructure.Repositories.Abstract;

public interface IUserRepository : IRepository<User, int>
{
    
}