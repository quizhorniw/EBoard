using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.EBoard.Application.Abstractions.Authentication;
using SolarLab.EBoard.Domain.Interfaces;
using SolarLab.EBoard.Infrastructure.Authentication;
using SolarLab.EBoard.Infrastructure.Persistence;

namespace SolarLab.EBoard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddServices()
            .AddDatabase(configuration)
            .AddAuthenticationInternal(configuration);
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services;
    }
    
    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opts => opts
            .UseNpgsql(configuration.GetConnectionString("EBoardPostgres"))
            .UseSnakeCaseNamingConvention());

        services.AddScoped<IAdPostsRepository, AdPostsRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        
        return services;
    }

    private static IServiceCollection AddAuthenticationInternal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IPasswordHasher, PasswordHasher>();

        return services;
    }
}