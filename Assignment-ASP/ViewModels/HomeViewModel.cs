using Assignment_ASP.Models;

namespace Assignment_ASP.ViewModels;

public class HomeViewModel
{
    public HeroModel Hero = new HeroModel()
    {
        TitleSmall = "WELCOME TO bmarketo SHOP",
        TitleLarge = "Exclusive Chair gold Collection.",
        ButtonText = "SHOP NOW",
        ButtonLink = "",
    };


    public ProductDisplayModel ProductDisplay = new ProductDisplayModel()
    {
        Title = "Best Collection",
        categories = new List<string>() 
        {
            "test",
            "tops",
            "computers",
            "phones"
        }
    };
}
