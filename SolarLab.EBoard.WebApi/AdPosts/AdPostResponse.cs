namespace SolarLab.EBoard.WebApi.AdPosts;

public sealed record AdPostResponse(
    Guid Id,
    string Title,
    string? Description,
    Guid CategoryId,
    decimal Price,
    Guid UserId,
    DateTime CreatedAt
    );