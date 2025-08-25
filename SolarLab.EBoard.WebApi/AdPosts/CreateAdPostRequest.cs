namespace SolarLab.EBoard.WebApi.AdPosts;

public sealed record CreateAdPostRequest(
    string Title,
    string? Description,
    Guid CategoryId,
    decimal Price
    );