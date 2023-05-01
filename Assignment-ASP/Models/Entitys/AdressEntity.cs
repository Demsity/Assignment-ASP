using Assignment_ASP.Models.Identity;

namespace Assignment_ASP.Models.Entitys
{
    public class AdressEntity
    {
        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public List<AppUser> Users = new List<AppUser>();
    }
}
