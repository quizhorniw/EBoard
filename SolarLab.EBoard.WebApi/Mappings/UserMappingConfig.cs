using Mapster;
using SolarLab.EBoard.Application.Users;
using SolarLab.EBoard.Application.Users.Login;
using SolarLab.EBoard.Application.Users.Register;
using SolarLab.EBoard.WebApi.Users;

namespace SolarLab.EBoard.WebApi.Mappings;

public sealed class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserDto, UserResponse>();
        config.NewConfig<RegisterUserRequest, RegisterUserCommand>();
        config.NewConfig<LoginUserRequest, LoginUserCommand>();
    }
}