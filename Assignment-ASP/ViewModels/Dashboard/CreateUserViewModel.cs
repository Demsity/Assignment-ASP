using System.ComponentModel.DataAnnotations;

namespace Assignment_ASP.ViewModels.Dashboard;

public class CreateUserViewModel
{
    [Display(Name = "First Name *")]
    [Required(ErrorMessage = "You must enter a first name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name *")]
    [Required(ErrorMessage = "You must enter a last name")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Street Name *")]
    [Required(ErrorMessage = "You must enter a street name")]
    public string StreetName { get; set; } = null!;

    [Display(Name = "City *")]
    [Required(ErrorMessage = "You must enter a city")]
    public string City { get; set; } = null!;

    [Display(Name = "Postal Code *")]
    [Required(ErrorMessage = "You must enter a postal code")]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "Mobile (Optional)")]
    [DataType(DataType.PhoneNumber)]
    public string? Mobile { get; set; }

    [Display(Name = "Company (Optional)")]
    public string? CompanyName { get; set; }

    [Display(Name = "Email *")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter a email adress (ex. domain@domain.com)")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must provide a Email Adress (ex. domain@domain.com)")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password *")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must enter a password (Minimum eight characters, at least one letter and one number)")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "You must provide a valid password (Minimum eight characters, at least one letter and one number)")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password *")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must confirm your password")]
    [Compare("Password", ErrorMessage = "The passwords does not match, please try again")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Upload Profile Image (Optional)")]
    [DataType(DataType.Upload)]
    public IFormFile? ImageFile { get; set; }

    [Display(Name = "Give this user Admin privileges")]
    public bool IsAdmin { get; set; } = false;
}
