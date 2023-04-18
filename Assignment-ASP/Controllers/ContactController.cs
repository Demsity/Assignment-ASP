using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers
{
    public class ContactController : Controller
    {

        public ContactViewModel ViewModel = new();
        public IActionResult Index()
        {
            ViewData["Title"] = "Contact";
            return View(ViewModel);
        }
    }
}
