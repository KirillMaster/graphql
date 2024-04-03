using Microsoft.EntityFrameworkCore;

namespace ProductsMicroservice;

public class Repository
{
    private readonly MyDbContext dbContext;

    public Repository(IDbContextFactory<MyDbContext> dbContextFactory)
    {
        dbContext = dbContextFactory.CreateDbContext();
    }

    public IQueryable<CatalogProduct> GetProducts()
    {
        return dbContext.Products;
    }

    public ValueTask DisposeAsync()
    {
        return dbContext.DisposeAsync();
    }
}