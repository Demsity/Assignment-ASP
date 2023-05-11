using Assignment_ASP.Context;
using Assignment_ASP.Helpers.Repositories;
using Assignment_ASP.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Assignment_ASP.Helpers.Services;

public class NewsletterService
{
    private readonly NewsletterRepository _newsletterRepo;

    public NewsletterService(NewsletterRepository newsletterRepo)
    {
        _newsletterRepo = newsletterRepo;
    }

    public async Task<IEnumerable<NewsletterEntity>> GetNewslettersAsync()
    {
        return await _newsletterRepo.GetAllAsync();
    }

    public async Task<bool> SaveNewsletterEntry(string email)
    {
        if (!email.IsNullOrEmpty())
        {
            var allReadyExsists = await _newsletterRepo.GetAsync(x => x.Email == email);
            if (allReadyExsists == null)
            {
                await _newsletterRepo.AddAsync(new NewsletterEntity { Email = email });
                return true;
            }
        }
        return false;
    }
}
