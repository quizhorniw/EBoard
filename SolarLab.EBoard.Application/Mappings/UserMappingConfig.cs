using Mapster;
using SolarLab.EBoard.Application.Users;
using SolarLab.EBoard.Domain.Users;

namespace SolarLab.EBoard.Application.Mappings;

public sealed class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>();
    }
}