using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.EBoard.Domain.Interfaces;
using SolarLab.EBoard.Infrastructure.Persistence;

namespace SolarLab.EBoard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddServices()
            .AddDatabase(configuration);
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services;
    }
    
    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opts => opts
            .UseNpgsql(configuration["DefaultConnection"])
            .UseSnakeCaseNamingConvention());

        services.AddScoped<IAdPostsRepository, AdPostsRepository>();
        
        return services;
    }
}