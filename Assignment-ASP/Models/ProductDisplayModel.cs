namespace Assignment_ASP.Models;

public class ProductDisplayModel
{
    public string Title { get; set; } = null!;

    //Change later to categorymodel?
    public List<string>? categories { get; set; }
}
