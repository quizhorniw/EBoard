using FluentValidation;

namespace SolarLab.EBoard.Application.Comments.Create;

internal sealed class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentValidator()
    {
        RuleFor(c => c.AdPostId).NotEmpty();
        RuleFor(c => c.Text).NotEmpty().MaximumLength(1000);
    }
}