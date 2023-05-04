using Assignment_ASP.Models;
using Assignment_ASP.Services;
using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    public ProductViewModel ViewModel = new();

    
    public IActionResult Index()
    {
        ViewData["Title"] = "Products";
        return View(ViewModel);
    }
    //SingleView
    public async Task<IActionResult> Details(int id)
    {
        ViewData["Title"] = "Products - ";
        if (id > 0) 
        {
            ProductModel _product = await _productService.GetProductById(id);
            if (_product != null)
            {
                ViewData["Title"] = _product.Name;
                return View(_product);
            }
        }
        return View("Index");
    }
}
