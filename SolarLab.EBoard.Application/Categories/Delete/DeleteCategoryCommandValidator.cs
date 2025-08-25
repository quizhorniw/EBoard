using FluentValidation;

namespace SolarLab.EBoard.Application.Categories.Delete;

internal sealed class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}