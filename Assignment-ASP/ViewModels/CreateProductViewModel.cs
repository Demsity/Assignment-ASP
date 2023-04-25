using Assignment_ASP.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment_ASP.ViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Please enter a product name")]
        [Display(Name = "Product name *")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a description")]
        [Display(Name = "Description *")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a price")]
        [Display(Name = "Price *")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a rating")]
        [Display(Name = "Rating * (Not an option in production)")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please enter the total number of ratings")]
        [Display(Name = "Total Ratings * (Not an option in production)")]
        public int TotalRatings { get; set; }

        [Required(ErrorMessage = "Please enter a stock amount")]
        [Display(Name = "Stock *")]
        public int StockTotal { get; set; } = 0;

        [Display(Name = "Upload Image (Optional)")]
        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "Please Choose atleast one category")]
        [Display(Name = "Categories (Choose one or more) *")]

        public List<CategoryModel> Categories { get; set; } = null!;
    }
}
