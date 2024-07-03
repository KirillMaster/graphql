using ProductsMicroservice.FullRelational;

namespace ProductsMicroservice;

public class Query
{
    //   [UsePaging(DefaultPageSize = 40)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Product> CatalogProducts([Service] Repository repository, string sku)
    {
        return repository.GetProducts().Where(x => x.Sku == sku);
    }
    
    // public IEnumerable<CategoryDto> Categories([Service] Repository repository, Guid categoryId, string sku, string selectedFilter = null)
    // {
    //     return repository.GetCategories()
    // }

    // [UseProjection]
    // [UseFiltering]
    // [UseSorting]
    // public IQueryable<ProductsMicroservice.ManyJsonbColumns.CatalogProduct> ProductsSliced([Service] Repository repository, string currency)
    // {
    //     return repository.GetSlicedProducts(currency);
    // }

    // public IQueryable<CustomersContext.Customer> Customers([Service] Repository repository, int count)
    // {
    //     return repository.GetCustomers(count);
    // }

}