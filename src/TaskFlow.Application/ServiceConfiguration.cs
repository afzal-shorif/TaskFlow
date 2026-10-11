using Microsoft.Extensions.DependencyInjection;

using TaskFlow.Infrastructure;

namespace TaskFlow.Application;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApplicationDepencency(this IServiceCollection service)
    {
        service.AddDbServiceConfiguration();

        return service;
    }
}
