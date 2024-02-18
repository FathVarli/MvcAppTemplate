using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcApp.Core.Settings;
using MvcApp.Infrastructure.Context;
using MvcApp.Infrastructure.Repositories;
using MvcApp.Infrastructure.Repositories.Base;
using MvcApp.Infrastructure.UnitOfWork;

namespace MvcApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceProvider = services.BuildServiceProvider();
        var appSettings = serviceProvider.GetRequiredService<AppSettings>();
        
        services.AddDbContextPool<AppDbContext>(options => options.UseNpgsql(appSettings.PostgresqlSetting.ConnectionString));
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddRepositories();

        return services;
    }
}