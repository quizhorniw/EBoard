using MediatR;

namespace SolarLab.EBoard.Application.Categories.Update;

public sealed record UpdateCategoryCommand(Guid Id, string Name, Guid? ParentId) : IRequest;