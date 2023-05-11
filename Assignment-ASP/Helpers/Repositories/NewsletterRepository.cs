using Assignment_ASP.Context;
using Assignment_ASP.Models.Entitys;

namespace Assignment_ASP.Helpers.Repositories;

public class NewsletterRepository : DataRepository<NewsletterEntity>
{
    public NewsletterRepository(DataContext context) : base(context)
    {
    }
}
