using Microsoft.Extensions.DependencyInjection;

namespace TaskFlow.Infrastructure;

public static class DbServiceConfiguration
{
    public static void AddDbServiceConfiguration(this IServiceCollection service)
    {
        service.AddDbContext<AppDbContext>(option => { });
    }
}
