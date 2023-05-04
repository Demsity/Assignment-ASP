using Assignment_ASP.Models;
using Assignment_ASP.Services;
using Assignment_ASP.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers;

[Authorize(Roles = "admin")]
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

    // Delete product from the list
    [HttpPost]
    public async Task<IActionResult> ManageProducts(int productId)
    {
        if (productId > 0)
        {
            if (await productService.DeleteProduct(productId))
            {
                TempData["Message"] = "Product has been deleted";
                return RedirectToAction("ManageProducts");
            }
        }

        TempData["Message"] = "Product could not be deleted";
        return RedirectToAction("ManageProducts");
    }

    public async Task<IActionResult> CreateProduct()
    {
        ViewData["Title"] = "Create Product";
        var viewModel = new CreateProductViewModel
        {
            Categories = await categoryService.GetAllCategoriesAsync()
        };
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

    public async Task<IActionResult> UpdateProduct(int Id)
    {
        ViewData["Title"] = "Update Product";
        if (Id > 0)
        {
            UpdateProductViewModel product = await productService.GetProductById(Id);
            if (product != null)
                return View(product);
        }
        TempData["Message"] = "Product was not found";
        return View("ManageProducts");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductViewModel viewModel)
    {
        ViewData["Title"] = "Update Product";
        if (ModelState.IsValid)
        {
            var result = await productService.UpdateProductAsync(viewModel);
            if (result)
                return RedirectToAction("ManageProducts");
        }
        return View(viewModel);
    }
}
