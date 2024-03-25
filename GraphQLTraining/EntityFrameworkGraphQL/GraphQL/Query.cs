using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkGraphQL.GraphQL;

public class Query
{
    public IQueryable<Product> GetProducts([Service]MyDbContext dbContext)
    {
        return dbContext.Products;
    }
}