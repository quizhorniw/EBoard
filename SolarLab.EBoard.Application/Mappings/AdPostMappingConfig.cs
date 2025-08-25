using Mapster;
using SolarLab.EBoard.Application.AdPosts;
using SolarLab.EBoard.Application.AdPosts.Create;
using SolarLab.EBoard.Domain.AdPosts;

namespace SolarLab.EBoard.Application.Mappings;

public sealed class AdPostMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAdPostCommand, AdPost>()
            .Map(dest => dest.Id, src => Guid.Empty);
        config.NewConfig<AdPost, AdPostDto>();
    }
}