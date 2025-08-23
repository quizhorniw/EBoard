using FluentValidation;

namespace SolarLab.EBoard.Application.AdPosts.Create;

internal sealed class CreateAdPostCommandValidator : AbstractValidator<CreateAdPostCommand>
{
    public CreateAdPostCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Title).NotEmpty().Length(3, 100);
        RuleFor(c => c.Description).MaximumLength(1000);
        RuleFor(c => c.Price).GreaterThanOrEqualTo(0);
    }
}