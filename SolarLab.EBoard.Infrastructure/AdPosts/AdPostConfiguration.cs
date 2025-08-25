using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarLab.EBoard.Domain.AdPosts;
using SolarLab.EBoard.Domain.Categories;
using SolarLab.EBoard.Domain.Users;

namespace SolarLab.EBoard.Infrastructure.AdPosts;

internal sealed class AdPostConfiguration : IEntityTypeConfiguration<AdPost>
{
    public void Configure(EntityTypeBuilder<AdPost> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(1000);
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.CreatedAt).IsRequired();
        
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}