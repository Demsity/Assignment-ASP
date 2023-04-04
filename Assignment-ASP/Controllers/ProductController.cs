using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
