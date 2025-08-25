namespace SolarLab.EBoard.WebApi.AdPosts;

public record UpdateAdPostRequest(
    string Title,
    string? Description,
    Guid CategoryId,
    decimal Price
    );