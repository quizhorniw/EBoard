using MediatR;
using SolarLab.EBoard.Application.Abstractions.Authentication;
using SolarLab.EBoard.Domain.Interfaces;
using SolarLab.EBoard.Domain.Users;

namespace SolarLab.EBoard.Application.Users.Register;

internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(IUsersRepository usersRepository, IPasswordHasher passwordHasher)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(
            request.Email,
            request.FirstName,
            request.LastName,
            _passwordHasher.Hash(request.Password)
            );
        
        await _usersRepository.AddAsync(user, cancellationToken);
        return user.Id;
    }
}