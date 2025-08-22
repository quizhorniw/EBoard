using SolarLab.EBoard.Domain.Entities;

namespace SolarLab.EBoard.Domain.Interfaces;

public interface IUsersRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(User user, CancellationToken cancellationToken = default);
}