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

    public PromotionModel Promotion = new PromotionModel()
    {
        Hook = "UP TO SALE",
        Title = "50% OFF",
        SubTitle = "Get The Best Price",
        Text = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",
        LinkText = "Discover More",
        LinkURL = ""
    };

    public TopSellersModel TopSellers = new TopSellersModel()
    {
        Title = "Top selling products this week"
    };
}
