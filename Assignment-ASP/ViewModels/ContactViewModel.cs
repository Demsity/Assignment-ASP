using Assignment_ASP.Models.Entitys;
using System.ComponentModel.DataAnnotations;

namespace Assignment_ASP.ViewModels;

public class ContactViewModel
{
    [Required(ErrorMessage = "Please enter your name")]
    [Display(Name = "Your Name *")]
    public string Name { get; set; } = null!;

    [Display(Name = "Your Email *")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter an email adress (ex. domain@domain.com)")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must provide a Email Adress (ex. domain@domain.com)")]
    public string Email { get; set; } = null!;

    [Display(Name = "Your Mobile (Optional)")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Your Company (Optional)")]
    public string? CompanyName { get; set; }

    [Required(ErrorMessage = "Please enter a message")]
    [Display(Name = "Write Something *")]
    public string Message { get; set; } = null!;

    public static implicit operator ContactMessageEntity(ContactViewModel viewModel)
    {
        return new ContactMessageEntity 
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            CompanyName = viewModel.CompanyName,
            Message = viewModel.Message,
            CreatedAt = DateTime.Now
        };
    }
}
