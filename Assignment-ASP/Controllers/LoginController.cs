using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserLoginViewModel viewModel)
        {
            ViewData["Title"] = "Register";

            return View(viewModel);
        }
    }
}
