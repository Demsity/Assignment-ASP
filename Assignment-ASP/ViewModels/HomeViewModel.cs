using Assignment_ASP.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment_ASP.ViewModels;

public class HomeViewModel
{

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter an email adress (ex. domain@domain.com)")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must provide a Email Adress (ex. domain@domain.com)")]
    public string NewsletterEmail { get; set; } = null!;



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
        NumberOfProducts = 8,
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
