using Mapster;
using SolarLab.EBoard.Application.Comments.Create;
using SolarLab.EBoard.WebApi.Endpoints.Comments;

namespace SolarLab.EBoard.WebApi.Mappings;

public sealed class CommentsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Create.Request, CreateCommentCommand>();
    }
}