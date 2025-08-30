using SolarLab.EBoard.Domain.Commons;

namespace SolarLab.EBoard.Domain.Comments;

public class Comment : Entity
{
    public Guid Id { get; private set; }
    public Guid AdPostId { get; private set; }
    public Guid UserId { get; private set; }
    public string Text { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    private Comment(Guid adPostId, Guid userId, string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Comment cannot be empty", nameof(text));
        }

        Id = Guid.NewGuid();
        AdPostId = adPostId;
        UserId = userId;
        Text = text.Trim();
        CreatedAt = DateTime.UtcNow;
    }

    public static Comment Create(Guid adPostId, Guid userId, string text) => new(adPostId, userId, text);
    
    public void ChangeText(string newText) => Text = newText;
}