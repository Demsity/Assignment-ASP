namespace Assignment_ASP.Models.Entitys;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Rating { get; set; }
    public int TotalRatings { get; set; }
    public int StockTotal { get; set; }
    public string? ImagePath { get; set; }

    public List<ProductCategoryEntity> Categories { get; set; } = null!;

}
