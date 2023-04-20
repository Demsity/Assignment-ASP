using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Assignment_ASP.Models.Entitys;

[PrimaryKey(nameof(productId), nameof(categoryId))]
public class ProductCategoryEntity
{
    [Key]
    public int productId { get; set; }
    public ProductEntity product { get; set; } = null!;

    [Key]
    public int categoryId { get; set; }
    public CategoryEntity category { get; set; } = null!;
}
