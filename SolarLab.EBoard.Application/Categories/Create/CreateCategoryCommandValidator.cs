using FluentValidation;

namespace SolarLab.EBoard.Application.Categories.Create;

internal sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(70);
    }
}