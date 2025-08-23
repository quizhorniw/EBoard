using MediatR;

namespace SolarLab.EBoard.Application.AdPosts.Archive;

public sealed record ArchiveAdPostCommand(Guid AdPostId, Guid UserId) : IRequest;