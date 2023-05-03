using Assignment_ASP.Context;
using Assignment_ASP.Models.Entitys;
using Assignment_ASP.Models.Identity;
using Assignment_ASP.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Assignment_ASP.Services;

public class AuthenticationService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IdentityContext _identityContext;
    private readonly SignInManager<AppUser> _signInManager;

    public AuthenticationService(UserManager<AppUser> userManager, IdentityContext identityContext, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
    }

    public async Task<AppUser> CheckIfUserExsistsByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<bool> RegisterUserAsync(UserRegisterViewModel viewModel)
    {
        var user = await CheckIfUserExsistsByEmailAsync(viewModel.Email);
        var roleName = "user";
        if (user == null) 
        {
            try
            {
                var _adress = await _identityContext.AspNetAdresses.Where(x => x.StreetName == viewModel.StreetName && x.PostalCode == viewModel.PostalCode && x.City == viewModel.City).FirstOrDefaultAsync();
                if (_adress == null) 
                {
                    _adress = new AdressEntity()
                    {
                        PostalCode = viewModel.PostalCode,
                        StreetName = viewModel.StreetName,
                        City = viewModel.City,
                    };

                    await _identityContext.AspNetAdresses.AddAsync(_adress);
                    _identityContext.SaveChanges();
                }

                if (!await _userManager.Users.AnyAsync())
                {
                    roleName = "admin";
                }


                AppUser newUser = new AppUser()
                {
                    UserName = viewModel.Email,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    //image
                    CompanyName = viewModel.CompanyName,
                    PhoneNumber = viewModel.Mobile,
                    AdressId = _adress.Id

                };


                var result = await _userManager.CreateAsync(newUser, viewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, roleName);
                    return true;
                }
            }
            catch
            {
                return false;

            }

        }

        return false;
    }

    public async Task<bool> LogInUserAsync(UserLoginViewModel viewModel)
    {
        var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
        if (appUser != null) 
        {
            var result = await _signInManager.PasswordSignInAsync(appUser, viewModel.Password, viewModel.RememberMe, false);
            if (result.Succeeded)
            {
                return true;
            }
        }
        return false;
    }

    public async Task<bool> LogOutUserAsync()
    {
        return false;
    }
}
