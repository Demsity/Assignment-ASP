using Assignment_ASP.Models.Entitys;
using Microsoft.AspNetCore.Identity;

namespace Assignment_ASP.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? ImageUrl { get; set; }
        public int AdressId { get; set; }
        public AdressEntity Adress { get; set; } = null!;
    }
}
