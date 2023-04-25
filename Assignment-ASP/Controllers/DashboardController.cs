using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers
{
    public class DashboardController : Controller
    {
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

        public IActionResult CreateProduct() 
        {
            ViewData["Title"] = "Create Product";
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel viewModel)
        {
            ViewData["Title"] = "Create Product";
            RedirectToAction("ManageProducts");
            return View(viewModel);
        }
    }
}
