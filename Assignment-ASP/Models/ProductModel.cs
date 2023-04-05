namespace Assignment_ASP.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string DescriptionShort { get; set; } = null!;
    public string? DescriptionLong { get; set; }
    public decimal Price { get; set;}
    public int Rating { get; set; }
    public int TotalRatings { get; set; }
    public int StockTotal { get; set; }
}
