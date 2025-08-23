using MediatR;
using SolarLab.EBoard.Domain.Users;

namespace SolarLab.EBoard.Application.Users.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IRequest<User?>;