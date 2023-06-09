﻿using Assignment_ASP.Models.Entitys;
using Assignment_ASP.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Assignment_ASP.ViewModels.Authentication;

public class UserRegisterViewModel
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
    [Required(ErrorMessage = "You must enter an email adress (ex. domain@domain.com)")]
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

    [Display(Name = "I have read an accepts the terms and agreements  *")]
    [Compare("AgreedToTerms", ErrorMessage = "You have to agree with 'Terms and agreements' to register")]
    public bool AgreeToTerms { get; set; }

    [HiddenInput]
    public bool AgreedToTerms { get; set; } = true;



    public static implicit operator AppUser(UserRegisterViewModel viewModel)
    {
        var _user = new AppUser
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            CompanyName = viewModel.CompanyName,
            PhoneNumber = viewModel.Mobile,
            PasswordHash = viewModel.Password,
        };

        if(viewModel.ImageFile != null)
        {
            _user.ImageUrl = $"{Guid.NewGuid()}-{viewModel.ImageFile.FileName}";
        }

        return _user;
    }

    public static implicit operator AdressEntity(UserRegisterViewModel viewModel)
    {
        return new AdressEntity
        {
            StreetName = viewModel.StreetName,
            City = viewModel.City,
            PostalCode = viewModel.PostalCode,
        };
    }

}


