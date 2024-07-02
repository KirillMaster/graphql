namespace ProductsMicroservice;

public class Query
{
   // [UsePaging(DefaultPageSize = 40)]
    // [UseProjection]
    // [UseFiltering]
    // [UseSorting]
    // public IQueryable<CatalogProduct> CatalogProducts([Service] Repository repository, int count)
    // {
    //     return repository.GetProducts(count);
    // }
    //
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ProductsMicroservice.ManyJsonbColumns.CatalogProduct> ProductsSliced([Service] Repository repository, string sku)
    {
        return repository.GetSlicedProducts(sku);
    }
}