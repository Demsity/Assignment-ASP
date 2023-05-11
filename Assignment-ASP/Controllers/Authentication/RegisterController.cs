using Assignment_ASP.Helpers.Services;
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
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserRegisterViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            
            if (viewModel != null)
            {
                var result = await _authenticationService.RegisterUserAsync(viewModel);
                if (result)
                    return RedirectToAction("Index", "Login");
            }
            ModelState.AddModelError("Model", "Something went wrong! Please contact customer support");
            return View(viewModel);
        }

        return View(viewModel);
    }
}
