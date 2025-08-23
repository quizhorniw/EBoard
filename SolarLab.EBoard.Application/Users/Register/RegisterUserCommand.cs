using MediatR;

namespace SolarLab.EBoard.Application.Users.Register;

public sealed record RegisterUserCommand(
    string Email,
    string FirstName, 
    string LastName,
    string Password
    ) : IRequest<Guid>;