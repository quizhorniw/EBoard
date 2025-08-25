using MediatR;

namespace SolarLab.EBoard.Application.AdPosts.Create;

public sealed record CreateAdPostCommand(
    string Title,
    string? Description,
    Guid CategoryId,
    decimal Price
    ) : IRequest<Guid>;