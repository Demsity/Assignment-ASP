namespace Assignment_ASP.Models;

public class ProductDisplayModel
{
    public string Title { get; set; } = null!;

    public int NumberOfProducts { get; set; }

    public bool GetAll { get; set; } = false;
}
