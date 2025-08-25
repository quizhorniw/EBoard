namespace SolarLab.EBoard.Application.Categories;

public sealed record CategoryDto(Guid Id, string Name, Guid? ParentId);