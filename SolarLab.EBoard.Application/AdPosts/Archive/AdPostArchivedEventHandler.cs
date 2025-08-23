using MediatR;
using SolarLab.EBoard.Domain.AdPosts;

namespace SolarLab.EBoard.Application.AdPosts.Archive;

public sealed class AdPostArchivedEventHandler : INotificationHandler<AdPostArchivedEvent>
{
    public async Task Handle(AdPostArchivedEvent notification, CancellationToken cancellationToken)
    {
        // TODO: Email subscribers of the post  
    }
}