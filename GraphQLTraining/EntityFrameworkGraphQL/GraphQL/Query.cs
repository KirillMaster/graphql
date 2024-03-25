using EntityFrameworkGraphQL.DAL;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkGraphQL.GraphQL;

public class Query
{
    public IQueryable<Product> GetProducts([Service]Repository repository)
    {
        return repository.GetProducts();
    }
    
    public IQueryable<Customer> GetCustomers([Service]Repository repository)
    {
        return repository.GetCustomers();
    }
    
    public IQueryable<Review> GetReviews([Service]Repository repository)
    {
        return repository.GetReviews();
    }
}