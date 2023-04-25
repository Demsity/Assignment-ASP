using Assignment_ASP.Context;
using Assignment_ASP.Models;
using Assignment_ASP.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Assignment_ASP.Services;

public class CategoryService
{
    private readonly DataContext _context;

    public CategoryService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryModel>> GetAllCategoriesAsync()
    {
        var _categories = new List<CategoryModel>();
        foreach (var category in await _context.Categories.ToListAsync()) 
        { 
            _categories.Add(category);
        }
        return _categories;
    }
}
