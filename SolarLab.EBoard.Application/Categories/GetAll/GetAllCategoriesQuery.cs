using MediatR;

namespace SolarLab.EBoard.Application.Categories.GetAll;

public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;