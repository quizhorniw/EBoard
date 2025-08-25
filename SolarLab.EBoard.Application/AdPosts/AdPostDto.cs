namespace SolarLab.EBoard.Application.AdPosts;

public sealed record AdPostDto(
    Guid Id,
    string Title,
    string? Description,
    Guid CategoryId,
    decimal Price,
    Guid UserId,
    DateTime CreatedAt
    );