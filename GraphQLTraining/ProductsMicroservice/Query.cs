namespace ProductsMicroservice;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<CatalogProduct> CatalogProducts([Service] Repository repository, int count)
    {
        return repository.GetProducts(count);
    }
    
    public IQueryable<CustomersContext.Customer> Customers([Service] Repository repository, int count)
    {
        return repository.GetCustomers(count);
    }

}