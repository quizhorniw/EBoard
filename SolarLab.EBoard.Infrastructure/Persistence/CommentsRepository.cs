using Microsoft.EntityFrameworkCore;
using SolarLab.EBoard.Domain.Comments;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Infrastructure.Persistence;

public class CommentsRepository : ICommentsRepository
{
    private readonly AppDbContext _context;

    public CommentsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Comment>> GetByAdPostIdAsync(Guid adPostId, CancellationToken cancellationToken = default)
    {
        return await _context.Comments.Where(c => c.AdPostId == adPostId)
            .ToListAsync(cancellationToken);
    }

    public async Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task AddAsync(Comment comment, CancellationToken cancellationToken = default)
    {
        await _context.Comments.AddAsync(comment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateTextAsync(Comment comment, CancellationToken cancellationToken = default)
    {
        _context.Update(comment);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var comment = await GetByIdAsync(id, cancellationToken);
        if (comment is null) return;
        
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync(cancellationToken);
    }
}