using Assignment_ASP.Context;
using Assignment_ASP.Models.Entitys;

namespace Assignment_ASP.Helpers.Repositories;

public class ContactMessageRepository : DataRepository<ContactMessageEntity>
{
    public ContactMessageRepository(DataContext context) : base(context)
    {
    }
}
