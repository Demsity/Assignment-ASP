using Assignment_ASP.Context;
using Assignment_ASP.Models;
using Assignment_ASP.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Assignment_ASP.Services;

public class ProductService
{

    private DataContext _context;

    public ProductService()
    {

    }

    public readonly List<ProductModel> Products = new List<ProductModel>()
    {
        new ProductModel(){ Id = 1, Name= "Test",Description= "Test",Price = 29,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 2, Name= "Test",Description= "Test",Price = 29,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 3, Name= "Test",Description= "Test",Price = 33,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 4, Name= "Test",Description= "Test",Price = 33,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 5, Name= "Test",Description= "Test",Price = 29,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 6, Name= "Test",Description= "Test",Price = 29,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 7, Name= "Test",Description= "Test",Price = 44,Rating = 4,StockTotal = 5,TotalRatings= 6,},
        new ProductModel(){ Id = 8, Name= "Test",Description= "Test",Price = 44,Rating = 4,StockTotal = 5,TotalRatings= 6,}
    };

    public async Task<Boolean> SaveProductAsync(ProductModel model)
    {
        if (model != null)
        {
            
            var _findProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (_findProduct == null)
            {
                // If product dosent exists, make a new
                ProductEntity _product = model;
                _context.Products.Add(_product);

                // Handle Categories
                foreach (var category in model.Categories)
                {
                    ProductCategoryEntity _category = new()
                    {
                        productId = _product.Id,
                        categoryId = category.Id

                    };
                    _context.ProductCategories.Add(_category);
                }
                
                await _context.SaveChangesAsync();
                return true;
                
            }

            // If product exists, update it
        }

        return false;
    }

    public List<ProductModel> GetProducts(int quantity)
    {
        return Products.Take(quantity).ToList();
    }

    public List<ProductModel> GetAllProducts() { return Products.ToList(); }
}
