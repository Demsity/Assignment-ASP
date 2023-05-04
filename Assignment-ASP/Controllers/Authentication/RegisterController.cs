using Assignment_ASP.Services;
using Assignment_ASP.ViewModels.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers.Authentication;

public class RegisterController : Controller
{

    private readonly AuthenticationService _authenticationService;

    public RegisterController(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Register";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserRegisterViewModel viewModel)
    {
        ViewData["Title"] = "Register";
        if (viewModel != null)
        {
            var result = await _authenticationService.RegisterUserAsync(viewModel);
            if (result)
                return RedirectToAction("Index", "Login");
        }

        return View(viewModel);
    }
}
