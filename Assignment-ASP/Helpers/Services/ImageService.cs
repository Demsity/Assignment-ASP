using Assignment_ASP.Models;
using Assignment_ASP.Models.Entitys;
using Assignment_ASP.Models.Identity;

namespace Assignment_ASP.Helpers.Services;

public class ImageService
{
    private readonly IWebHostEnvironment _environment;

    public ImageService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<bool> SaveProductImageAsync(ProductEntity product, IFormFile file)
    {
        try
        {
            string filePath = $"{_environment.WebRootPath}/images/products/{product.ImagePath}";
            await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<bool> SaveUserImageAsync(AppUser user, IFormFile file)
    {
        try
        {
            string filePath = $"{_environment.WebRootPath}/images/users/{user.ImageUrl}";
            await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return true;
        }
        catch
        {
            return false;
        }
    }
}
