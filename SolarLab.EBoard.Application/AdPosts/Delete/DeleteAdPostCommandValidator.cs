using FluentValidation;

namespace SolarLab.EBoard.Application.AdPosts.Delete;

internal sealed class DeleteAdPostCommandValidator : AbstractValidator<DeleteAdPostCommand>
{
    public DeleteAdPostCommandValidator()
    {
        RuleFor(c => c.AdPostId).NotEmpty();
    }
}