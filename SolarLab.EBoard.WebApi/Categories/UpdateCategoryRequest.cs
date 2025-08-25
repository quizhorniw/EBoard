namespace SolarLab.EBoard.WebApi.Categories;

public sealed record UpdateCategoryRequest(string Name, Guid? ParentId);