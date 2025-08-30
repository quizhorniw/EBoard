using Mapster;
using SolarLab.EBoard.Application.Categories;
using SolarLab.EBoard.Application.Categories.Create;
using SolarLab.EBoard.Application.Categories.Update;
using SolarLab.EBoard.WebApi.Categories;

namespace SolarLab.EBoard.WebApi.Mappings;

public sealed class CategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CategoryDto, CategoryResponse>();
        config.NewConfig<CreateCategoryRequest, CreateCategoryCommand>();
        config.NewConfig<UpdateCategoryRequest, UpdateCategoryCommand>();
    }
}