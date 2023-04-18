using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers
{
    public class ProductController : Controller
    {
        public ProductViewModel ViewModel = new();

        //SingleView
        public IActionResult Index()
        {
            ViewData["Title"] = "Products";
            return View(ViewModel);
        }
    }
}
