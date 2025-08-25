using Mapster;
using MapsterMapper;
using SolarLab.EBoard.WebApi.Mappings;

namespace SolarLab.EBoard.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services
            .AddContractMappings();

        return services;
    }

    private static IServiceCollection AddContractMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        
        config.Scan(
            typeof(AdPostMappingConfig).Assembly,
            typeof(UserMappingConfig).Assembly,
            typeof(CategoryMappingConfig).Assembly
            );
        
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}