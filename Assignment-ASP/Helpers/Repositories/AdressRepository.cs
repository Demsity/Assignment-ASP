using Assignment_ASP.Context;
using Assignment_ASP.Models.Entitys;

namespace Assignment_ASP.Helpers.Repositories
{
    public class AdressRepository : IdentityRepository<AdressEntity>
    {
        public AdressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
