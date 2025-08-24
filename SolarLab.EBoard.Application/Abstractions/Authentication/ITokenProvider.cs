using SolarLab.EBoard.Domain.Users;

namespace SolarLab.EBoard.Application.Abstractions.Authentication;

public interface ITokenProvider
{
    string CreateToken(User user);
}