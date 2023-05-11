using Assignment_ASP.Helpers.Services;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.LogInUserAsync(viewModel);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Model", "Wrong password or email");
                return View(viewModel);
            }
            ModelState.AddModelError("Model", "Please fill in all the required fields");
            return View(viewModel);
        }
    }
}
