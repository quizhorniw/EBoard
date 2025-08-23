using MediatR;

namespace SolarLab.EBoard.Application.AdPosts.Create;

public sealed record CreateAdPostCommand(
    Guid UserId,
    string Title,
    string? Description,
    decimal Price
    ) : IRequest<Guid>;