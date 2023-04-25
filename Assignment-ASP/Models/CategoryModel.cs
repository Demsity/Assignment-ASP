using Assignment_ASP.Models.Entitys;

namespace Assignment_ASP.Models;

public class CategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool isActive { get; set; } = false;

    public static implicit operator CategoryEntity(CategoryModel model)
    {
        return new CategoryEntity 
        {
            Id = model.Id,
            Name = model.Name,
        };
    }

    public static implicit operator CategoryModel(CategoryEntity entity)
    {
        return new CategoryModel 
        { 
            Id = entity.Id, 
            Name = entity.Name,
        };
    }
}
