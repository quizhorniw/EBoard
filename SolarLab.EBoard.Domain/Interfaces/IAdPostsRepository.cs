using SolarLab.EBoard.Domain.AdPosts;

namespace SolarLab.EBoard.Domain.Interfaces;

public interface IAdPostsRepository
{
    Task<IEnumerable<AdPost>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<AdPost?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(AdPost adPost, CancellationToken cancellationToken = default);
    Task UpdateAsync(AdPost adPost, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}