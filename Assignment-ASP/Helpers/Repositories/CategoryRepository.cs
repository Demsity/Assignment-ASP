using Assignment_ASP.Context;
using Assignment_ASP.Models.Entitys;

namespace Assignment_ASP.Helpers.Repositories;

public class CategoryRepository : DataRepository<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
