using Microsoft.Extensions.DependencyInjection;

namespace MvcApp.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        return services;
    }
}