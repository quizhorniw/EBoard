namespace SolarLab.EBoard.WebApi.Users;

public sealed record RegisterUserRequest(
    string Email,
    string? PhoneNumber,
    string FirstName, 
    string LastName,
    string Password
    );