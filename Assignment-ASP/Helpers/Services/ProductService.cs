using Assignment_ASP.Helpers.Repositories;
using Assignment_ASP.Models;
using Assignment_ASP.Models.Entitys;
using Assignment_ASP.ViewModels.Dashboard;

namespace Assignment_ASP.Helpers.Services;

public class ProductService
{

  
    private readonly CategoryService _categoryService;
    private readonly ProductRepository _productRepo;
    private readonly ProductCategoryRepository _productCategoryRepo;
    private readonly ImageService _imageService;

    public ProductService(CategoryService categoryService, ImageService imageService, ProductCategoryRepository productCategoryRepo, ProductRepository productRepo)
    {
        _categoryService = categoryService;
        _imageService = imageService;
        _productCategoryRepo = productCategoryRepo;
        _productRepo = productRepo;
    }

    public async Task<bool> SaveProductAsync(CreateProductViewModel model)
    {
        if (model != null)
        {

            var _findProduct = await _productRepo.GetAsync(x => x.Name == model.Name);
            if (_findProduct == null)
            {
                // If product dosent exists, make a new
                ProductEntity _product = model;
                _product = await _productRepo.AddAsync(_product);

                // Handel Images
                if (model.Image != null)
                {
                    await _imageService.SaveProductImageAsync(_product, model.Image);
                }

                // Handle Categories

                foreach (var category in model.Categories)
                {
                    if (category.isActive == true)
                    {
                        await _productCategoryRepo.AddAsync(new ProductCategoryEntity { productId = _product.Id, categoryId = category.Id});
                    }
                }

                return true;
            }
        }
        return false;
    }

    public async Task<bool> UpdateProductAsync(UpdateProductViewModel model)
    {
        if (model != null)
        {
            var _product = await _productRepo.GetAsync(x => x.Id == model.Id);
            if (_product != null)
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

                    _product = await _productRepo.UpdateAsync(_product);
                }


                // Handle Categories
                if (model.Categories != null)
                {
                    foreach (var category in model.Categories)
                    {
                        var lookUp = await _productCategoryRepo.GetAsync(x => x.productId == _product.Id && x.categoryId == category.Id);
                        var _category = new ProductCategoryEntity
                        {
                            productId = model.Id,
                            categoryId = category.Id,
                        };

                        if (category.isActive == true)
                        {
                            if (lookUp == null)
                            {
                                await _productCategoryRepo.AddAsync(_category);
                            }
                        } else
                        {
                            if (lookUp != null)
                            {

                                await _productCategoryRepo.DeleteAsync(lookUp);
                            }
                        }
                    }
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
                var product = await _productRepo.GetAsync(x => x.Id == productId);
                if (product != null)
                {
                    await _productRepo.DeleteAsync(product);
                    return true;
                }
            }
            catch
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
            ProductModel _product = await _productRepo.GetAsync(x => x.Id == productId);
            if (_product != null)
            {
                var lookUp = await _productCategoryRepo.GetAllAsync(x => x.productId == productId);
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
            return null!;
        }
        catch
        {
            return null!;
        }

    }

    public async Task<List<ProductModel>> GetProducts(int quantity)
    {
        List<ProductModel> _products = new List<ProductModel>();
        foreach (var productEntity in await _productRepo.GetAllAsync(quantity))
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
        foreach (var productEntity in await _productRepo.GetAllAsync())
        {
            var lookUp = await _productCategoryRepo.GetAllAsync(x => x.productId == productEntity.Id);
            var _categories = new List<CategoryModel>();
            foreach (var entry in lookUp)
            {
                CategoryModel category = await _categoryService.GetCategoryById(entry.categoryId);
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
