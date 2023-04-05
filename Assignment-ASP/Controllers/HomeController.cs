using Assignment_ASP.Models;
using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers
{
    public class HomeController : Controller
    {

        public HomeViewModel HomeViewModel = new();

        public IActionResult Index()
        {
           
            ViewData["Title"] = "Home";
            return View(HomeViewModel);
        }
    }
}
