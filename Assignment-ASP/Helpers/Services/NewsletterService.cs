using Assignment_ASP.Context;
using Assignment_ASP.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Assignment_ASP.Helpers.Services;

public class NewsletterService
{
    private readonly DataContext dataContext;

    public NewsletterService(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<List<NewsletterEntity>> GetNewslettersAsync()
    {
        return await dataContext.Newsletters.ToListAsync();
    }

    public async Task<bool> SaveNewsletterEntry(string email)
    {
        if (!email.IsNullOrEmpty())
        {
            var allReadyExsists = await dataContext.Newsletters.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (allReadyExsists == null)
            {
                dataContext.Newsletters.Add(new NewsletterEntity() { Email = email });
                await dataContext.SaveChangesAsync();
                return true;
            }
        }
        return false;
    }
}
