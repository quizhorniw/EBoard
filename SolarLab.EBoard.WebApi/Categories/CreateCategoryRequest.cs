namespace SolarLab.EBoard.WebApi.Categories;

public sealed record CreateCategoryRequest(string Name, Guid? ParentId);