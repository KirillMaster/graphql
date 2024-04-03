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

    public string Test([Service] Repository repository)
    {
        return "";
        //return repository.GetProducts().Select(x => x.datajson).Select(x => x.Sku).FirstOrDefault().ToString();
    }
}