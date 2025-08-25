using FluentValidation;

namespace SolarLab.EBoard.Application.AdPosts.Update;

internal sealed class UpdateAdPostCommandValidator : AbstractValidator<UpdateAdPostCommand>
{
    public UpdateAdPostCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty().Length(3, 100);
        RuleFor(c => c.Description).MaximumLength(1000);
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.Price).GreaterThanOrEqualTo(0);
    }
}