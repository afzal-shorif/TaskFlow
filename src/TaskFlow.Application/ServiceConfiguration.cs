using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Infrastructure;
using TaskFlow.Application.Service;
using Microsoft.AspNetCore.Identity;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application;

public static class ServiceConfiguration
{
	public static IServiceCollection AddApplicationDepencency(this IServiceCollection service)
	{
		service.AddDbServiceConfiguration();
		service.AddScoped<ICurrentUserService, CurrentUserService>();
		service.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();

		return service;
	}
}
