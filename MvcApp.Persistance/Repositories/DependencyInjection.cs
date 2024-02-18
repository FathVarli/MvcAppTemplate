using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcApp.Infrastructure.Context;
using MvcApp.Infrastructure.Repositories.Abstract;
using MvcApp.Infrastructure.Repositories.Base;
using MvcApp.Infrastructure.Repositories.Concrete;
using MvcApp.Infrastructure.UnitOfWork;

namespace MvcApp.Infrastructure.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}