using MediatR;

namespace SolarLab.EBoard.Application.Users.GetById;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<UserDto?>;