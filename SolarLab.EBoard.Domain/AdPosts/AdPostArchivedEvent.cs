using MediatR;

namespace SolarLab.EBoard.Domain.AdPosts;

public sealed record AdPostArchivedEvent(Guid AdPostId) : INotification;