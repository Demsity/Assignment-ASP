using Assignment_ASP.ViewModels.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers.Authentication
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            var user = User.Identity;
            AccountViewModel accountViewModel = new AccountViewModel()
            {
                
                UserName = user.Name
            };
            return View();
        }
    }
}
