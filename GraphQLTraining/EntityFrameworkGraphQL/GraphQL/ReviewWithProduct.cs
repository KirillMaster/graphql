using EntityFrameworkGraphQL.DAL;
using HotChocolate.Resolvers;

namespace EntityFrameworkGraphQL.GraphQL;

public class ReviewWithProduct
{
    public int ReviewId { get; set; }
    public int ProductId { get; set; }
    public string ReviewText { get; set; }

    public async Task<string> GetProductName([Parent] ReviewWithProduct reviewWithProduct, IResolverContext resolverContext, [Service] Repository repository)
    {
        var result = await resolverContext.BatchDataLoader<int, Product>(
                async (keys, ct) =>
                {
                    var result = await repository.GetProductsByIds(keys.ToArray());
                    return result.ToDictionary(x => x.Id);
                })
            .LoadAsync(reviewWithProduct.ProductId);
        
        return result.Name;
    }
}