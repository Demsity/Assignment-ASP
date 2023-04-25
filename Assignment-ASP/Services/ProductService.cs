using Assignment_ASP.Context;
using Assignment_ASP.Models;
using Assignment_ASP.Models.Entitys;
using Assignment_ASP.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment_ASP.Services;

public class ProductService
{

    private DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
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

    public async Task<Boolean> SaveProductAsync(CreateProductViewModel model)
    {
        if (model != null)
        {
            
            var _findProduct = await _context.Products.FirstOrDefaultAsync(x => x.Name == model.Name);
            if (_findProduct == null)
            {
                // If product dosent exists, make a new
                ProductEntity _product = model;
                _context.Products.Add(_product);
                await _context.SaveChangesAsync();


                // Handle Categories

                foreach (var category in model.Categories)
                {
                    if(category.isActive == true)
                    {
                        ProductCategoryEntity _category = new()
                        {
                            productId = _product.Id,
                            categoryId = category.Id

                        };
                        _context.ProductCategories.Add(_category);
                    }
                }

                
                await _context.SaveChangesAsync();
                return true;
                
            }

            // If product exists, update it
        }

        return false;
    }

    public async Task<List<ProductModel>> GetProducts(int quantity)
    {
        List<ProductModel> _products = new List<ProductModel>();
        foreach (var productEntity in await _context.Products.Take(quantity).ToListAsync()) 
        { 
            var productModel = new ProductModel();
            productModel.Id = productEntity.Id;
            productModel.Name = productEntity.Name;
            productModel.Description = productEntity.Description;
            productModel.Price = productEntity.Price;
            productModel.Rating = productEntity.Rating;
            productModel.TotalRatings = productEntity.TotalRatings;
            productModel.StockTotal = productEntity.StockTotal;
            productModel.ImagePath = productEntity.ImagePath;

            _products.Add(productModel);
        }
        return _products;
    }

    public async Task<List<ProductModel>> GetAllProducts() 
    {
        List<ProductModel> _products = new List<ProductModel>();
        foreach (var productEntity in await _context.Products.ToListAsync())
        {
            var productModel = new ProductModel();
            productModel.Id = productEntity.Id;
            productModel.Name = productEntity.Name;
            productModel.Description = productEntity.Description;
            productModel.Price = productEntity.Price;
            productModel.Rating = productEntity.Rating;
            productModel.TotalRatings = productEntity.TotalRatings;
            productModel.StockTotal = productEntity.StockTotal;
            productModel.ImagePath = productEntity.ImagePath;

            _products.Add(productModel);
        }
        return _products;
    }
}
