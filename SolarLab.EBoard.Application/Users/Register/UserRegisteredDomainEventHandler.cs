using MediatR;
using SolarLab.EBoard.Domain.Users;

namespace SolarLab.EBoard.Application.Users.Register;

internal sealed class UserRegisteredDomainEventHandler : INotificationHandler<UserRegisteredDomainEvent>
{
    public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        // TODO: Email user to confirm registration
    }
}