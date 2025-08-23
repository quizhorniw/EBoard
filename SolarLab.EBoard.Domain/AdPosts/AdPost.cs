using SolarLab.EBoard.Domain.Commons;

namespace SolarLab.EBoard.Domain.AdPosts;

public sealed class AdPost : Entity
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public AdPost(Guid userId, string title, string? description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is required.", nameof(title));
        }

        if (price < 0)
        {
            throw new ArgumentException("Price cannot be negative.", nameof(price));
        }

        Id = Guid.NewGuid();
        UserId = userId;
        Title = title;
        Description = description;
        Price = price;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateDetails(string title, string? description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is required.", nameof(title));
        }

        if (price < 0)
        {
            throw new ArgumentException("Price cannot be negative.", nameof(price));
        }
        
        Title = title;
        Description = description;
        Price = price;
    }
}