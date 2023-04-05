using Assignment_ASP.Models;

namespace Assignment_ASP.Services;

public class ProductService
{

    public ProductService()
    {

    }

    private readonly List<ProductModel> Products = new List<ProductModel>()
    {
        new ProductModel(){ Id = 1, Name= "Test",DescriptionShort= "Test",Price = 29,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 2, Name= "Test",DescriptionShort= "Test",Price = 29,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 3, Name= "Test",DescriptionShort= "Test",Price = 33,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 4, Name= "Test",DescriptionShort= "Test",Price = 33,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 5, Name= "Test",DescriptionShort= "Test",Price = 29,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 6, Name= "Test",DescriptionShort= "Test",Price = 29,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 7, Name= "Test",DescriptionShort= "Test",Price = 44,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 8, Name= "Test",DescriptionShort= "Test",Price = 44,Rating = 4,StockTotal = 5,TotalRatings= 6,}
    };

    public List<ProductModel> GetProducts(int quantity)
    {
        return Products;
    }
}
