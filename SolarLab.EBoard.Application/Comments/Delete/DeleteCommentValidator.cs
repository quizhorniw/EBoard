using FluentValidation;

namespace SolarLab.EBoard.Application.Comments.Delete;

internal sealed class DeleteCommentValidator : AbstractValidator<DeleteCommentCommand>
{
    public DeleteCommentValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}