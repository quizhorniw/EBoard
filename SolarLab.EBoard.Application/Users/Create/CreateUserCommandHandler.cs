using MediatR;
using SolarLab.EBoard.Domain.Interfaces;
using SolarLab.EBoard.Domain.Users;

namespace SolarLab.EBoard.Application.Users.Create;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUsersRepository _usersRepository;

    public CreateUserCommandHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(
            request.Email,
            request.FirstName,
            request.LastName,
            request.PasswordHash
            );
        
        await _usersRepository.AddAsync(user, cancellationToken);
        return user.Id;
    }
}