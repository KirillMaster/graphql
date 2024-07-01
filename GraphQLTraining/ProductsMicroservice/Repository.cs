using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace ProductsMicroservice;

public class Repository
{
    private readonly MyDbContext dbContext;

    public Repository(IDbContextFactory<MyDbContext> dbContextFactory)
    {
        dbContext = dbContextFactory.CreateDbContext();
    }

    public IQueryable<CatalogProduct> GetProducts(int count)
    {
        return dbContext.Products.Take(count);
    }
    

    public IQueryable<CustomersContext.Customer> GetCustomers(int count)
    {
        return dbContext.Customers.Take(count);
    }
    public object Test()
    {
        return null;
        // using (var context = dbContext)
        // {
        //     var catalogProduct = context.Products.Select(x => x.DataJson).FirstOrDefault();
        //     
        //     var deserializeOptions = new JsonSerializerSettings
        //     {
        //         ContractResolver = new DefaultContractResolver
        //         {
        //             NamingStrategy = new SnakeCaseNamingStrategy()
        //         },
        //     };
        //     
        //     var deserialized =
        //         JsonConvert.DeserializeObject<Tenengroup.CatalogProxy.Domain.Catalog.Product>(catalogProduct, deserializeOptions);
        //
        //     var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(deserialized, 
        //         new JsonSerializerSettings
        //         {
        //             ContractResolver = new DefaultContractResolver
        //             {
        //                 NamingStrategy = new DefaultNamingStrategy()
        //             },
        //             Formatting = Formatting.Indented,
        //             StringEscapeHandling = StringEscapeHandling.Default
        //         });
        //     
        //    
        //     return serialized;
        // }
    }

    public ValueTask DisposeAsync()
    {
        return dbContext.DisposeAsync();
    }
}