using EntityFrameworkGraphQL.DAL;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkGraphQL.GraphQL;

public class Query
{
    [UseProjection]
    public IQueryable<Product> GetProducts([Service]Repository repository)
    {
        return repository.GetProducts();
    }
    
    [UseProjection]
    public IQueryable<Customer> GetCustomers([Service]Repository repository)
    {
        return repository.GetCustomers();
    }
    
    [UseProjection]
    public IQueryable<Review> GetReviews([Service]Repository repository)
    {
        return repository.GetReviews();
    }
    
    public List<ReviewWithProduct> GetReviewsWithProducts([Service] Repository repository)
    {
        return repository.GetReviews().Select(x => new ReviewWithProduct
        {
            ReviewText = x.Text,
            ProductName = x.Product.Name
        }).ToList();
    }
}