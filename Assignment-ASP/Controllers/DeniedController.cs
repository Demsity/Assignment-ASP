using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
