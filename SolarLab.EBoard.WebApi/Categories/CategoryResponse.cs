namespace SolarLab.EBoard.WebApi.Categories;

public sealed record CategoryResponse(Guid Id, string Name, Guid? ParentId);