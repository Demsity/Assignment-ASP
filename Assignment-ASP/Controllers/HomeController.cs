using Assignment_ASP.Models;
using Assignment_ASP.Services;
using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Assignment_ASP.Controllers;

public class HomeController : Controller
{
    private readonly NewsletterService newsletterService;

    public HomeController(NewsletterService newsletterService)
    {
        this.newsletterService = newsletterService;
    }

    public HomeViewModel HomeViewModel = new();

    public IActionResult Index()
    {
       
        return View(HomeViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(HomeViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
        
            var result = await newsletterService.SaveNewsletterEntry(viewModel.NewsletterEmail);
            if (result)
            {
                ModelState.AddModelError("Model", "Subscibed to newsletter! Welcome!");
                return View(viewModel);
            }
        }
        ModelState.AddModelError("Model", "Could not subscribe to newsletter");
        return View(viewModel);
    }
}
