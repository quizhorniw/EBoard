using Mapster;
using SolarLab.EBoard.Application.Comments;
using SolarLab.EBoard.Domain.Comments;

namespace SolarLab.EBoard.Application.Mappings;

public class CommentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Comment, CommentDto>();
    }
}