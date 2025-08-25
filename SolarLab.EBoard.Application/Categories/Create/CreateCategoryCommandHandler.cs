using MediatR;
using SolarLab.EBoard.Domain.Categories;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.Categories.Create;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoriesRepository _categoriesRepository;

    public CreateCategoryCommandHandler(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name, null);
        
        var parent = request.ParentId.HasValue 
            ? await _categoriesRepository.GetByIdAsync(request.ParentId.Value, cancellationToken) 
            : null;
        category.ParentId = parent?.Id ?? null;
        
        await _categoriesRepository.AddAsync(category, cancellationToken);

        return category.Id;
    }
}