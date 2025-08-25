using Mapster;
using SolarLab.EBoard.Application.Categories;
using SolarLab.EBoard.Domain.Categories;

namespace SolarLab.EBoard.Application.Mapping;

public sealed class CategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Category, CategoryDto>();
    }
}