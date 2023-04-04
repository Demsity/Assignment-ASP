using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
