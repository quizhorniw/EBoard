using Mapster;
using SolarLab.EBoard.Application.AdPosts;
using SolarLab.EBoard.Application.AdPosts.Create;
using SolarLab.EBoard.Application.AdPosts.Update;
using SolarLab.EBoard.WebApi.AdPosts;

namespace SolarLab.EBoard.WebApi.Mappings;

public sealed class AdPostMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AdPostDto, AdPostResponse>();
        config.NewConfig<CreateAdPostRequest, CreateAdPostCommand>();
        config.NewConfig<UpdateAdPostRequest, UpdateAdPostCommand>()
            .Map(dest => dest.Id, src => Guid.Empty);
    }
}