using Mapster;
using SolarLab.EBoard.Application.AdPosts;
using SolarLab.EBoard.Domain.AdPosts;

namespace SolarLab.EBoard.Application.Mappings;

public sealed class AdPostMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AdPost, AdPostDto>();
    }
}