using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Register";
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserRegisterViewModel viewModel)
        {
            ViewData["Title"] = "Register";

            return View(viewModel);
        }
    }
}
