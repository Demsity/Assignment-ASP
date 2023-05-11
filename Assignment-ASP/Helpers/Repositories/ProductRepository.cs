using Assignment_ASP.Context;
using Assignment_ASP.Models.Entitys;

namespace Assignment_ASP.Helpers.Repositories;

public class ProductRepository : DataRepository<ProductEntity>
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}
