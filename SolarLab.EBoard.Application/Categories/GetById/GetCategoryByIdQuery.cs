using MediatR;

namespace SolarLab.EBoard.Application.Categories.GetById;

public sealed record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto?>;