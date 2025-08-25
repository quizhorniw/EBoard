using MediatR;

namespace SolarLab.EBoard.Application.AdPosts.Update;

public sealed record UpdateAdPostCommand(
    Guid Id,
    string Title,
    string? Description,
    Guid CategoryId,
    decimal Price
    ) : IRequest;