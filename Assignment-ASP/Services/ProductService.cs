using Assignment_ASP.Context;
using Assignment_ASP.Models;
using Assignment_ASP.Models.Entitys;
using Assignment_ASP.ViewModels.Dashboard;
using Microsoft.EntityFrameworkCore;

namespace Assignment_ASP.Services;

public class ProductService
{

    private DataContext _context;
    private CategoryService _categoryService;
    private readonly ImageService _imageService;

    public ProductService(DataContext context, CategoryService categoryService, ImageService imageService)
    {
        _context = context;
        _categoryService = categoryService;
        _imageService = imageService;
    }

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

                if(model.Image != null) {
                    await _imageService.SaveProductImageAsync(_product, model.Image);
                }
                
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

        }

        return false;
    }

    public async Task<bool> UpdateProductAsync(UpdateProductViewModel model)
    {
        if(model != null)
        {
            var _product = await _context.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
            if( _product != null)
            {
                // Update Information
                if (!string.IsNullOrEmpty(model.Name) && !string.IsNullOrEmpty(model.Description) && model.Price > 0)
                {
                    _product.Name = model.Name;
                    _product.Description = model.Description;
                    _product.Price = model.Price;
                    _product.Rating = model.Rating;
                    _product.TotalRatings = model.TotalRatings;
                    _product.StockTotal = model.StockTotal;

                    _context.Products.Update(_product);
                }

                await _context.SaveChangesAsync();

                // Handle Categories
                if (model.Categories != null)
                {
                    foreach (var category in model.Categories)
                    {
                        var lookUp = await _context.ProductCategories.FirstOrDefaultAsync(x => x.productId == model.Id && x.categoryId == category.Id);
                        var _category = new ProductCategoryEntity
                        {
                            productId = model.Id,
                            categoryId = category.Id,
                        };

                        if (category.isActive == true)
                        {
                            if (lookUp == null)
                            {
                                _context.ProductCategories.Add(_category);

                            } 
                        } else
                        {
                            if (lookUp != null)
                            {
                                
                                _context.ProductCategories.Remove(lookUp);
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                return true;
            }
        }
        return false;
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        if (productId > 0)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => productId == x.Id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
            } catch
            {
                return false;
            }
            
        }
        return false;
    }

    public async Task<ProductModel> GetProductById(int productId)
    {
        try
        {
            ProductModel _product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (_product != null)
            {
                var lookUp = await _context.ProductCategories.Where(x => x.productId == _product.Id).ToListAsync();
                List<CategoryModel> _allCategories = await _categoryService.GetAllCategoriesAsync();
                var _categories = new List<CategoryModel>();

                foreach (var category in _allCategories) 
                {
                    foreach (var entry in lookUp)
                    {
                        if (entry.categoryId == category.Id)
                        {
                            category.isActive = true;
                        }
                    }
                    _categories.Add(category);
                }

                _product.Categories = _categories;
                return _product;
            }
            return null;
        } catch
        {
            return null;
        }
        
    }

    public async Task<List<ProductModel>> GetProducts(int quantity)
    {
        List<ProductModel> _products = new List<ProductModel>();
        foreach (var productEntity in await _context.Products.Include(x => x.Categories).Take(quantity).ToListAsync()) 
        {
            var productModel = new ProductModel
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Description = productEntity.Description,
                Price = productEntity.Price,
                Rating = productEntity.Rating,
                TotalRatings = productEntity.TotalRatings,
                StockTotal = productEntity.StockTotal,
                ImagePath = productEntity.ImagePath,
            };

            _products.Add(productModel);
        }
        return _products;
    }

    public async Task<List<ProductModel>> GetAllProducts() 
    {



        List<ProductModel> _products = new List<ProductModel>();
        foreach (var productEntity in await _context.Products.ToListAsync())
        {
            var lookUp = await _context.ProductCategories.Where(x => x.productId == productEntity.Id).ToListAsync();
            var _categories = new List<CategoryModel>();
            foreach (var entry in lookUp)
            {
                CategoryModel category = await _context.Categories.Where(x => x.Id == entry.categoryId).FirstOrDefaultAsync();
                category.isActive = true;
                _categories.Add(category);
            }

            var productModel = new ProductModel();
            productModel.Id = productEntity.Id;
            productModel.Name = productEntity.Name;
            productModel.Description = productEntity.Description;
            productModel.Price = productEntity.Price;
            productModel.Rating = productEntity.Rating;
            productModel.TotalRatings = productEntity.TotalRatings;
            productModel.StockTotal = productEntity.StockTotal;
            productModel.ImagePath = productEntity.ImagePath;
            productModel.Categories = _categories;

            _products.Add(productModel);
        }
        return _products;
    }
}
