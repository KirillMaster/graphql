using EntityFrameworkGraphQL.DAL;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkGraphQL.GraphQL;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
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

    [UseProjection]
    public Product GetProductDumb(int id, [Service] Repository repository)
    {
        return repository.GetProduct(id);
    }
    
    public Task<Product> GetProduct(int id, IResolverContext context, [Service] Repository repository)
    {
        return context.BatchDataLoader<int, Product>(
                async (keys, ct) =>
                {
                    var result = await repository.GetProductsByIds(keys.ToArray());
                    return result.ToDictionary(x => x.Id);
                })
            .LoadAsync(id);
    }
    
    public List<ReviewWithProduct> GetReviewsWithProducts([Service] Repository repository)
    {
        return repository.GetReviews().Select(x => new ReviewWithProduct
        {
            ReviewId = x.Id,
            ProductId = x.ProductId,
            ReviewText = x.Text,
        }).ToList();
    }
}