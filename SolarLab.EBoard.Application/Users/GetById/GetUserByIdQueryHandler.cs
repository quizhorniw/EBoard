using MediatR;
using SolarLab.EBoard.Domain.Interfaces;
using SolarLab.EBoard.Domain.Users;

namespace SolarLab.EBoard.Application.Users.GetById;

public sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly IUsersRepository _usersRepository;

    public GetUserByIdQueryHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _usersRepository.GetByIdAsync(request.UserId, cancellationToken);
    }
}