using FluentValidation;

namespace SolarLab.EBoard.Application.AdPosts.Archive;

internal sealed class ArchiveAdPostCommandValidator : AbstractValidator<ArchiveAdPostCommand>
{
    public ArchiveAdPostCommandValidator()
    {
        RuleFor(c => c.AdPostId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}