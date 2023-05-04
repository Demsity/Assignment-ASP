using Assignment_ASP.Services;
using Assignment_ASP.ViewModels.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers.Authentication
{
    public class LoginController : Controller
    {

        private readonly AuthenticationService _authenticationService;

        public LoginController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel viewModel)
        {
            ViewData["Title"] = "Register";
            var result = await _authenticationService.LogInUserAsync(viewModel);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
    }
}
