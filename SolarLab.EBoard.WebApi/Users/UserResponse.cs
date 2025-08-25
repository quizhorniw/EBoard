namespace SolarLab.EBoard.WebApi.Users;

public sealed record UserResponse(
    Guid Id,
    string Email,
    string? PhoneNumber,
    string FirstName,
    string LastName
    );