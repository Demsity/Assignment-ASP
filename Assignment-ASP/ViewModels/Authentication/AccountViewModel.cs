using Assignment_ASP.Models.Identity;

namespace Assignment_ASP.ViewModels.Authentication;

public class AccountViewModel
{
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
}
