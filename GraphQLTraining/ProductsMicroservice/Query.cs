namespace ProductsMicroservice;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<CatalogProduct> CatalogProducts([Service] Repository repository)
    {
        return repository.GetProducts();
    }
}