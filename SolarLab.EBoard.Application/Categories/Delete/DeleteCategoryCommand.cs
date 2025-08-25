using MediatR;

namespace SolarLab.EBoard.Application.Categories.Delete;

public sealed record DeleteCategoryCommand(Guid Id) : IRequest;