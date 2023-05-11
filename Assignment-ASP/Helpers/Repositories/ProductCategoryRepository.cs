using Assignment_ASP.Context;
using Assignment_ASP.Models.Entitys;

namespace Assignment_ASP.Helpers.Repositories;

public class ProductCategoryRepository : DataRepository<ProductCategoryEntity>
{
    public ProductCategoryRepository(DataContext context) : base(context)
    {
    }
}
