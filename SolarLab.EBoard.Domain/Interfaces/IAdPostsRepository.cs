using SolarLab.EBoard.Domain.Entities;

namespace SolarLab.EBoard.Domain.Interfaces;

public interface IAdPostsRepository
{
    Task<IEnumerable<AdPost>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<AdPost?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(AdPost adPost, CancellationToken cancellationToken = default);
    Task UpdateAsync(AdPost adPost, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}