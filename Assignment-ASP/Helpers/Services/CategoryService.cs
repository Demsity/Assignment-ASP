using Assignment_ASP.Helpers.Repositories;
using Assignment_ASP.Models;

namespace Assignment_ASP.Helpers.Services;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepo;

    public CategoryService(CategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<CategoryModel> GetCategoryById(int id)
    {
        return await _categoryRepo.GetAsync(x => x.Id == id);
    }

    public async Task<List<CategoryModel>> GetAllCategoriesAsync()
    {
        var _categories = new List<CategoryModel>();
        foreach (var category in await _categoryRepo.GetAllAsync())
        {
            _categories.Add(category);
        }
        return _categories;
    }
}
