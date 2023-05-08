using Assignment_ASP.Services;
using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ASP.Controllers;

public class ContactController : Controller
{
    private readonly ContactMessagesService contactMessagesService;

    public ContactController(ContactMessagesService contactMessagesService)
    {
        this.contactMessagesService = contactMessagesService;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Contact";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactViewModel viewModel)
    {
        if (ModelState.IsValid) 
        {
            if (await contactMessagesService.SaveMessageAsync(viewModel))
            {
                //success message
                return RedirectToAction("Index");
            }
        }
        //fail Message
        return View(viewModel);
    }
}
