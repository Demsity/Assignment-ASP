using Assignment_ASP.Models.Entitys;

namespace Assignment_ASP.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set;}
    public int Rating { get; set; }
    public int TotalRatings { get; set; }
    public int StockTotal { get; set; } = 0;
    public string? ImagePath { get; set; }

    public List<CategoryModel> Categories { get; set; } = null!;


    public static implicit operator ProductEntity(ProductModel model)
    {
        return new ProductEntity
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Rating = model.Rating,
            TotalRatings = model.TotalRatings,
            StockTotal = model.StockTotal,
            ImagePath = model.ImagePath,
        };
    }

    public static implicit operator ProductModel(ProductEntity entity)
    {
        return new ProductModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            Rating = entity.Rating,
            TotalRatings = entity.TotalRatings,
            StockTotal = entity.StockTotal,
            ImagePath = entity.ImagePath,

        };
    }
}
