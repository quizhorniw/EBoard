namespace SolarLab.EBoard.Domain.Entities;

public sealed class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }

    public User(string email, string firstName, string lastName, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
        {
            throw new ArgumentException("Invalid email address.", nameof(email));
        }

        if (string.IsNullOrWhiteSpace(firstName) || firstName.Any(char.IsWhiteSpace))
        {
            throw new ArgumentException("Invalid first name.", nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Any(char.IsWhiteSpace))
        {
            throw new ArgumentException("Invalid last name.", nameof(lastName));
        }
        
        Id = Guid.NewGuid();
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PasswordHash = passwordHash;
    }
}