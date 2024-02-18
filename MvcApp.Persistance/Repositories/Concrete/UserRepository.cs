using MvcApp.Domain.Entities.Concrete;
using MvcApp.Infrastructure.Context;
using MvcApp.Infrastructure.Repositories.Abstract;
using MvcApp.Infrastructure.Repositories.Base;

namespace MvcApp.Infrastructure.Repositories.Concrete;

public class UserRepository : Repository<User,int>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}