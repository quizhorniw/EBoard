using MediatR;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.Categories.Update;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoriesRepository _categoriesRepository;

    public UpdateCategoryCommandHandler(ICategoriesRepository repository)
    {
        _categoriesRepository = repository;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoriesRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
        {
            throw new KeyNotFoundException("Category not found");
        }
        
        category.Rename(request.Name);
        category.ParentId = request.ParentId;
        
        await _categoriesRepository.UpdateAsync(category, cancellationToken);
    }
}