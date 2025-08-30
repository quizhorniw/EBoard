using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarLab.EBoard.Domain.AdPosts;
using SolarLab.EBoard.Domain.Comments;

namespace SolarLab.EBoard.Infrastructure.Comments;

internal sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.AdPostId).IsRequired();
        builder.HasIndex(c => c.AdPostId);

        builder.Property(c => c.UserId).IsRequired();
        builder.Property(c => c.Text).IsRequired().HasMaxLength(1000);
        
        builder.HasOne<AdPost>()
            .WithMany()
            .HasForeignKey(c => c.AdPostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}