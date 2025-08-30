using Microsoft.EntityFrameworkCore;
using SolarLab.EBoard.Domain.AdPosts;
using SolarLab.EBoard.Domain.Categories;
using SolarLab.EBoard.Domain.Comments;
using SolarLab.EBoard.Domain.Users;

namespace SolarLab.EBoard.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<AdPost> AdPosts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}