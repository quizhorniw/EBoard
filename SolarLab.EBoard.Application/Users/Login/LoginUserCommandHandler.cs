using System.Security.Authentication;
using MediatR;
using SolarLab.EBoard.Application.Abstractions.Authentication;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.Users.Login;

internal sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenProvider _tokenProvider;

    public LoginUserCommandHandler(IUsersRepository usersRepository, IPasswordHasher passwordHasher, ITokenProvider tokenProvider)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _tokenProvider = tokenProvider;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null)
        {
            throw new AuthenticationException("No user found");
        }
        
        var verified = _passwordHasher.Verify(request.Password, user.PasswordHash);
        if (!verified)
        {
            throw new AuthenticationException("Invalid password");
        }
        
        var token = _tokenProvider.CreateToken(user);
        return token;
    }
}