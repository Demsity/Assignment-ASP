namespace Assignment_ASP.Models.Entitys;

public class CategoryEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public List<ProductCategoryEntity> Products { get; set; } = null!;
}
