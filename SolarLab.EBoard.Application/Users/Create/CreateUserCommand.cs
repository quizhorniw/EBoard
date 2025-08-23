using MediatR;

namespace SolarLab.EBoard.Application.Users.Create;

public sealed record CreateUserCommand(
    string Email,
    string FirstName, 
    string LastName,
    string PasswordHash
    ) : IRequest<Guid>;