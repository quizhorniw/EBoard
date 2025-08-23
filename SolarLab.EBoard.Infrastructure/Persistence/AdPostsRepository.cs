using Microsoft.EntityFrameworkCore;
using SolarLab.EBoard.Domain.AdPosts;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Infrastructure.Persistence;

public class AdPostsRepository : IAdPostsRepository
{
    private readonly AppDbContext _context;

    public AdPostsRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<AdPost>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.AdPosts.ToListAsync(cancellationToken);
    }

    public async Task<AdPost?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.AdPosts.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task AddAsync(AdPost adPost, CancellationToken cancellationToken = default)
    {
        await _context.AdPosts.AddAsync(adPost, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(AdPost adPost, CancellationToken cancellationToken = default)
    {
        _context.AdPosts.Update(adPost);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ad = await GetByIdAsync(id, cancellationToken);
        if (ad is null) return;
        
        _context.AdPosts.Remove(ad);
        await _context.SaveChangesAsync(cancellationToken);
    }
}