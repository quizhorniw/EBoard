using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.EBoard.Application.Mappings;

namespace SolarLab.EBoard.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config
            .RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddContractMappings();
        
        return services;
    }
    
    private static IServiceCollection AddContractMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        
        config.Scan(
            typeof(AdPostMappingConfig).Assembly,
            typeof(UserMappingConfig).Assembly,
            typeof(CategoryMappingConfig).Assembly,
            typeof(CommentMappingConfig).Assembly
        );
        
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}