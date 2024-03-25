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