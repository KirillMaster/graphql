using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkGraphQL.DAL;

public class Repository : IAsyncDisposable
{
    private readonly MyDbContext dbContext;

    public Repository(IDbContextFactory<MyDbContext> dbContextFactory)
    {
        dbContext = dbContextFactory.CreateDbContext();
    }

    public IQueryable<Product> GetProducts()
    {
        return dbContext.Products;
    }
    
    public async Task<IEnumerable<Product>> GetProductsByIds(int[] ids)
    {
        return await dbContext.Products.Where(x => ids.Contains(x.Id)).ToArrayAsync();
    }

    public Product GetProduct(int id)
    {
        return dbContext.Products.First(x => x.Id == id);
    }
    
    public IQueryable<Customer> GetCustomers()
    {
        return dbContext.Customers;
    }
    
    public IQueryable<Review> GetReviews()
    {
        return dbContext.Reviews;
    }

    public ValueTask DisposeAsync()
    {
        return dbContext.DisposeAsync();
    }
}