using Assignment_ASP.Context;
using Assignment_ASP.Models.Entitys;
using Assignment_ASP.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment_ASP.Services;

public class ContactMessagesService
{
    private readonly DataContext _context;

    public ContactMessagesService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<ContactMessageEntity>> GetAllMessages()
    {
        return await _context.ContactMessages.ToListAsync();
    }

    public async Task<bool> SaveMessageAsync(ContactViewModel viewModel)
    {
        var result = await _context.ContactMessages.AddAsync(viewModel);
        if (result != null)
        {
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
