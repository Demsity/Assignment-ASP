using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageUsers() 
        {
            return View();
        }

        public IActionResult ManageProducts() 
        {
            return View();
        }
    }
}
