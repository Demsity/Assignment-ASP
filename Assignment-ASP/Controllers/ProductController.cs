using Assignment_ASP.Helpers.Services;
using Assignment_ASP.Models;
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
        return View(ViewModel);
    }
    //SingleView
    public async Task<IActionResult> Details(int id)
    {
        if (id > 0) 
        {
            ProductModel _product = await _productService.GetProductById(id);
            if (_product != null)
            {
                
                return View(_product);
            }
        }
        return View("Index");
    }
}
