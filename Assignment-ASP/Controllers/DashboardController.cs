using Assignment_ASP.Models;
using Assignment_ASP.Models.Identity;
using Assignment_ASP.Services;
using Assignment_ASP.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Assignment_ASP.Controllers;

[Authorize(Roles = "admin")]
public class DashboardController : Controller
{
    private readonly ProductService productService;
    private readonly CategoryService categoryService;
    private readonly AuthenticationService authenticationService;
    public DashboardController(ProductService productService, CategoryService categoryService, AuthenticationService authenticationService)
    {
        this.productService = productService;
        this.categoryService = categoryService;
        this.authenticationService = authenticationService;
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

    // Update Admin Status
    [HttpPost]
    public async Task<IActionResult> ManageUsers(string userId)
    {
        if (!userId.IsNullOrEmpty())
        {
            var result = await authenticationService.UpdateAdminAsync(userId);
            if (result)
            {
                return View();
            }
        }
        return View();
    }

    public IActionResult CreateUser()
    {
        ViewData["Title"] = "Create User";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            ViewData["Title"] = "Create User";
            if (viewModel != null)
            {
                var result = await authenticationService.CreateFromDashboardUserAsync(viewModel);
                if (result)
                    return RedirectToAction("ManageUsers");
            }

            ModelState.AddModelError("Model", "Something went wrong! Could not register user");
            return View(viewModel);

        }

        return View(viewModel);
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
                return RedirectToAction("ManageProducts");
            }
        }

        ModelState.AddModelError("Model", "Something went wrong! Could not delete product");
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

            ModelState.AddModelError("Model", "Something went wrong! Could not create the product");
            return View(viewModel);
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
        ModelState.AddModelError("Model", "Something went wrong! Could not find the product");
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

            ModelState.AddModelError("Model", "Something went wrong! Could not update the product");
            return View(viewModel);

        }
        return View(viewModel);
    }
}
