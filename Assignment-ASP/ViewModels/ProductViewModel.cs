using Assignment_ASP.Models;

namespace Assignment_ASP.ViewModels;

public class ProductViewModel
{

    //SingleView
    public BreadcrumbsModel Breadcrumbs = new BreadcrumbsModel()
    {
        CurrentPage = "PRODUCTS"
    };

    public ProductDisplayModel ProductDisplay = new ProductDisplayModel()
    {
        Title = "PRODUCTS",
        GetAll = true

    };

}
