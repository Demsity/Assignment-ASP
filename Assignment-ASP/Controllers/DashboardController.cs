using Assignment_ASP.Models;
using Assignment_ASP.Services;
using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers;

public class DashboardController : Controller
{
    private readonly ProductService productService;
    private readonly CategoryService categoryService;

    public DashboardController(ProductService productService, CategoryService categoryService)
    {
        this.productService = productService;
        this.categoryService = categoryService;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Dashboard";
        return View();
    }

    public IActionResult ManageUsers() 
    {
        ViewData["Title"] = "Manage Users";
        return View();
    }

    public IActionResult CreateUser() 
    {
        ViewData["Title"] = "Create User";
        return View();        
    }

    public IActionResult ManageProducts() 
    {
        ViewData["Title"] = "Manage Products";
        return View();
    }

    public async Task<IActionResult> CreateProduct() 
    {
        ViewData["Title"] = "Create Product";
        var viewModel = new CreateProductViewModel();
        viewModel.Categories = new List<CategoryModel>();
        viewModel.Categories = await categoryService.GetAllCategoriesAsync();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductViewModel viewModel)
    {
        ViewData["Title"] = "Create Product";
        if (ModelState.IsValid)
        {
            var result = await productService.SaveProductAsync(viewModel);
            if (result)
                return RedirectToAction("ManageProducts");
        }

        return View(viewModel);
    }
}
