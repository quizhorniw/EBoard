using MapsterMapper;
using MediatR;
using SolarLab.EBoard.Domain.Categories;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.Categories.GetById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(ICategoriesRepository categoriesRepository, IMapper mapper)
    {
        _categoriesRepository = categoriesRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _categoriesRepository.GetByIdAsync(request.Id, cancellationToken);
        return result is not null ? _mapper.Map<CategoryDto>(result) : null;
    }
}