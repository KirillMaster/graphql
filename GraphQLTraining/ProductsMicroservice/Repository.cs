using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using ProductsMicroservice.FullRelational;
using ProductsMicroservice.ManyJsonbColumns;
using CatalogProduct = ProductsMicroservice.OneJsonbColumn.CatalogProduct;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace ProductsMicroservice;

public class Repository
{
    private readonly MyDbContext dbContext;

    public Repository(IDbContextFactory<MyDbContext> dbContextFactory)
    {
        dbContext = dbContextFactory.CreateDbContext();
    }

    // public void Insert()
    // {
    //     CleanDb();
    //     for (int i = 0; i < 50000; i++)
    //     {
    //         InsertInternal();
    //         if (i % 1000 == 0)
    //         {
    //             dbContext.SaveChanges();
    //         }
    //         Console.WriteLine(i);
    //     }
    //
    // }

    // private void InsertInternal()
    // {
    //     var rand = new Random();
    //     var deserialized = JsonConvert.DeserializeObject<Product>(File.ReadAllText(@"C:\home\GraphQL\graphql\GraphQLTraining\ProductsMicroservice\FullRelational\catalog_pascal.json"));
    //
    //     var random = new Random();
    //     deserialized.Uid = rand.Next(int.MaxValue);
    //     deserialized.CurrencyCode = GetRandomCurrency();
    //     deserialized.Sku = GenerateRandomString(12);
    //     deserialized.VersionId =  random.NextInt64(long.MaxValue);
    //     // deserialized.ProductRibbons.ForEach((x )=>
    //     // {
    //     //     x.Sku = deserialized.Sku;
    //     //     x.VersionId = deserialized.VersionId;
    //     //     x.CurrencyCode = deserialized.CurrencyCode;
    //     //     x.Id = rand.Next(int.MaxValue);
    //     // });
    //     
    //     deserialized.Media.Items.ForEach(x =>
    //     {
    //         x.ProductUid = deserialized.Uid;
    //         x.Id = rand.Next(int.MaxValue);
    //     });
    //
    //     foreach (var category in deserialized.Categories)
    //     {
    //         category.Uid = GenerateRandomString(24);
    //         if (category.Options != null)
    //             foreach (var option in category.Options)
    //             {
    //                 option.CategoryUid = category.Uid;
    //             }
    //     }
    //
    //     foreach (var showAndHide in deserialized.ShowAndHides)
    //     {
    //         showAndHide.Id = rand.Next(int.MaxValue);
    //         showAndHide.ProductUid = deserialized.Uid;
    //     }
    //
    //     foreach (var field in deserialized.Fields)
    //     {
    //         field.Id = rand.Next(int.MaxValue);
    //         field.ProductUid = deserialized.Uid;
    //     }
    //
    //     foreach (var relationship in deserialized.Relationships)
    //     {
    //         relationship.Id = rand.Next(int.MaxValue);
    //         relationship.ProductUid = deserialized.Uid;
    //
    //         foreach (var relatedProduct in relationship.RelatedProducts)
    //         {
    //             relatedProduct.RelationshipId = relationship.Id;
    //         }
    //     }
    //
    //     dbContext.Products.Add(deserialized);
    // }

    private static string GenerateRandomString(int length)
    {
        var rand = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());
    }

    private string GetRandomCurrency()
    {
        var rand = new Random();
        var c = rand.Next(0, 2);
        switch (c)
        {
            case 0: return "USD";
            case 1: return "CAD";
            case 2: return "EUR";
            default: return "USD";
        }
    }

    private void CleanDb()
    {
        dbContext.Database.ExecuteSqlRaw("SET session_replication_role = 'replica';");

        // Delete data from all tables
        foreach (var entityType in dbContext.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            dbContext.Database.ExecuteSqlRaw($"TRUNCATE TABLE \"{tableName}\" CASCADE;");
        }

        // Enable foreign key checks
        dbContext.Database.ExecuteSqlRaw("SET session_replication_role = 'origin';");
    }

    public IQueryable<Product> GetProducts()
    {
        return dbContext.Products;
    }
    
    // public IQueryable<CatalogProduct> GetOneColumnProducts()
    // {
    //     return dbContext.OneColumnProducts;
    // }
    
    // public IQueryable<CatalogProduct> GetSlicedProducts(string currency)
    // {
    //     return dbContext.ProductsSliced.Where(x => x.CurrencyCode == currency);
    // }

    // public IQueryable<ManyJsonbColumns.CatalogProduct> GetSlicedProducts(string sku)
    // {
    //     return dbContext.ProductsSliced.Where(x => x.Sku == sku).Take(100);
    // }


    // public IQueryable<CustomersContext.Customer> GetCustomers(int count)
    // {
    //     return dbContext.Customers.Take(count);
    // }
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