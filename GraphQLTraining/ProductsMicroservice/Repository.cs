using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using ProductsMicroservice.FullRelational;
using ProductsMicroservice.ManyJsonbColumns;
using Category = ProductsMicroservice.FullRelational.Category;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace ProductsMicroservice;

public class Repository
{
    private readonly MyDbContext dbContext;

    public Repository(IDbContextFactory<MyDbContext> dbContextFactory)
    {
        dbContext = dbContextFactory.CreateDbContext();
    }

    public void Insert()
    {
        CleanDb();
        
        
        for (int i = 0; i < 1000; i++)
        {
            try
            {
                InsertProducts();
                if (i % 100 == 0)
                {
                    dbContext.SaveChanges();
                }
              
                
        
                Console.WriteLine(i);
            }
            catch (Exception)
            {
                
            }
           
        }
        
        
        for (int i = 0; i < 10; i++)
        {
            try
            {
                InsertCategories();
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

    private void InsertProducts()
    {
        var rand = new Random();
        var deserialized = JsonConvert.DeserializeObject<Product>(File.ReadAllText(@"C:\home\GraphQL\graphql\GraphQLTraining\ProductsMicroservice\FullRelational\catalog_pascal.json"));

        var random = new Random();
        deserialized.CurrencyCode = GetRandomCurrency();
        deserialized.Sku = GenerateRandomString(12);
        deserialized.VersionId =  random.NextInt64(long.MaxValue);
        // deserialized.ProductRibbons.ForEach((x )=>
        // {
        //     x.Sku = deserialized.Sku;
        //     x.VersionId = deserialized.VersionId;
        //     x.CurrencyCode = deserialized.CurrencyCode;
        //     x.Id = rand.Next(int.MaxValue);
        // });
        
        deserialized.Media.Items.ForEach(x =>
        {
            x.Sku = deserialized.Sku;
            x.VersionId = deserialized.VersionId;
            x.CurrencyCode = deserialized.CurrencyCode;
            x.Id = rand.Next(int.MaxValue);
        });

        foreach (var category in deserialized.Categories)
        {
            category.Uid = GenerateRandomString(24);
            if (category.Options != null)
                foreach (var option in category.Options)
                {
                    option.CategoryUid = category.Uid;
                }
        }

        foreach (var showAndHide in deserialized.ShowAndHides)
        {
            showAndHide.Id = rand.Next(int.MaxValue);
            showAndHide.Sku = deserialized.Sku;
            showAndHide.VersionId = deserialized.VersionId;
            showAndHide.CurrencyCode = deserialized.CurrencyCode;
        }

        foreach (var field in deserialized.Fields)
        {
            field.Id = rand.Next(int.MaxValue);
            field.Sku = deserialized.Sku;
            field.VersionId = deserialized.VersionId;
            field.CurrencyCode = deserialized.CurrencyCode;
        }

        foreach (var relationship in deserialized.Relationships)
        {
            relationship.Id = rand.Next(int.MaxValue);
            relationship.Sku = deserialized.Sku;
            relationship.VersionId = deserialized.VersionId;
            relationship.CurrencyCode = deserialized.CurrencyCode;

            foreach (var relatedProduct in relationship.RelatedProducts)
            {
                relatedProduct.RelationshipId = relationship.Id;
            }
        }

        dbContext.Products.Add(deserialized);
    }

    private void InsertCategories()
    {
        var productKeys = dbContext.Products.Select(x => new { x.Sku, x.VersionId, x.CurrencyCode }).ToList();

        var facets = new string[] { "For Denis Mum", "For Shmulik Kids", "For Tamas baby" };
        var filters = new string[] { "1 inscription", "2 inscription", "3 inscription" };

        var categoryGuid = Guid.NewGuid();
        var rand = new Random();
        
        
        var category = new ProductsMicroservice.FullRelational.Category
        {
            CategoryExternalId = categoryGuid,
            Content = new Content
            {
                Name = "Super category",
                BackofficeName = "Backoffice super category",
                CategoryDescription = "Description",
                ImageAlt = "alt",
                ImageTitle = "super title",
                UrlName = "image",
                CategoryImageLink = "http://localhost:1234"
            },
            Seo = new Seo
            {
                Description = "description",
                Title = "title",
                HeaderScript = "script",
                CategoryLowerSubtitle = "lowerSubtitle",
                SeoCategories = new List<SeoCategory>
                {
                    new SeoCategory
                    {
                        Name = "name",
                        CategoryId = categoryGuid,
                        UrlName = "urlName"
                    }
                }
            },
            Facets = new List<Facet>
            {
                new Facet
                {
                    Id = rand.Next(int.MaxValue),
                    Name = filters[rand.Next(filters.Length)],
                    Position = rand.Next(100),
                    CategoryId = categoryGuid,
                    FieldName = facets[rand.Next(facets.Length)]
                },
                new Facet
                {
                    Id = rand.Next(int.MaxValue),
                    Name = filters[rand.Next(filters.Length)],
                    Position = rand.Next(100),
                    CategoryId = categoryGuid,
                    FieldName = facets[rand.Next(facets.Length)]
                },
                new Facet
                {
                    Id = rand.Next(int.MaxValue),
                    Name = filters[rand.Next(filters.Length)],
                    Position = rand.Next(100),
                    CategoryId = categoryGuid,
                    FieldName = facets[rand.Next(facets.Length)]
                },
            },
        };


        var categoryProducts = new List<CategoryProduct>();

        for (int i = 0; i < 10; i++)
        {
            var key = productKeys[rand.Next(productKeys.Count())];
            categoryProducts.Add(new CategoryProduct
            {
                ProductSku = key.Sku,
                ProductVersionId = key.VersionId,
                ProductCurrencyCode = key.CurrencyCode,
                CategoryId = categoryGuid,
                BestSellersSortPosition = rand.Next(100),
                OnlineDateSortPosition = rand.Next(100),
                ProductFacets = new List<ProductFacet>
                {
                    new ProductFacet
                    {
                        Id = rand.Next(int.MaxValue),
                        Sku = key.Sku,
                        Value = filters[rand.Next(filters.Length)],
                        CategoryId = categoryGuid,
                        FieldName = facets[0]
                    },
                    new ProductFacet
                    {
                        Id = rand.Next(int.MaxValue),
                        Sku = key.Sku,
                        Value = filters[rand.Next(filters.Length)],
                        CategoryId = categoryGuid,
                        FieldName = facets[1]
                    },
                    new ProductFacet
                    {
                        Id = rand.Next(int.MaxValue),
                        Sku = key.Sku,
                        Value = filters[rand.Next(filters.Length)],
                        CategoryId = categoryGuid,
                        FieldName = facets[2]
                    }
                }
            });
        }

        category.ProductsInCategory = categoryProducts;

        dbContext.Categories.Add(category);
    }

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

    public IQueryable<Category> GetCategories()
    {
        return dbContext.Categories;
    }

    public IQueryable<CategoryProduct> GetCategoryProducts()
    {
        return dbContext.CategoryProducts;
    }

    public IQueryable<ProductFacet> GetProductFacets()
    {
        return dbContext.ProductFacets;
    }

    public IQueryable<Facet> GetFacets(Guid categoryId)
    {
        return dbContext.Facets.Where(x => x.CategoryId == categoryId);
    }

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