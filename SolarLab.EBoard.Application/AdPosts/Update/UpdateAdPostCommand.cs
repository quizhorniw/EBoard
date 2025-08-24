using MediatR;

namespace SolarLab.EBoard.Application.AdPosts.Update;

public sealed record UpdateAdPostCommand(
    Guid AdPostId,
    string Title,
    string? Description,
    decimal Price
    ) : IRequest;