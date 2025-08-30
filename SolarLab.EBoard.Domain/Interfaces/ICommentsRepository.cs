using SolarLab.EBoard.Domain.Comments;

namespace SolarLab.EBoard.Domain.Interfaces;

public interface ICommentsRepository
{
    Task<IEnumerable<Comment>> GetByAdPostIdAsync(Guid adPostId, CancellationToken cancellationToken = default);
    Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Comment comment, CancellationToken cancellationToken = default);
    Task UpdateTextAsync(Comment comment, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}