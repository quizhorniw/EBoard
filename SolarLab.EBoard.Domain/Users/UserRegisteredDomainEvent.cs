using MediatR;

namespace SolarLab.EBoard.Domain.Users;

public sealed record UserRegisteredDomainEvent(Guid UserId) : INotification;