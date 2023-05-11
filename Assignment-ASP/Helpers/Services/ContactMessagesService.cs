using Assignment_ASP.Context;
using Assignment_ASP.Helpers.Repositories;
using Assignment_ASP.Models.Entitys;
using Assignment_ASP.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment_ASP.Helpers.Services;

public class ContactMessagesService
{
    private readonly ContactMessageRepository _contactMessageRepo;

    public ContactMessagesService(ContactMessageRepository contactMessageRepo)
    {
        _contactMessageRepo = contactMessageRepo;
    }

    public async Task<IEnumerable<ContactMessageEntity>> GetAllMessages()
    {
        return await _contactMessageRepo.GetAllAsync();
    }

    public async Task<bool> SaveMessageAsync(ContactViewModel viewModel)
    {
        var result = await _contactMessageRepo.AddAsync(viewModel);
        if (result != null)
        {
            return true;
        }
        return false;
    }
}
