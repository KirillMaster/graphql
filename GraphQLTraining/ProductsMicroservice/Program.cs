using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using ProductsMicroservice;
using ProductsMicroservice.FullRelational;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<MyDbContext>(
    options => options
        .UseNpgsql("Host=localhost;Port=5432;Database=CatalogProducts;Username=postgres;Password=1234;",
            b =>
            {
                b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); 
                b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            })
        .UseLowerCaseNamingConvention());

builder.Services.AddTransient<Repository>();

//builder.Services.AddSingleton(ConnectionMultiplexer.Connect("localhost:6379"));

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<MyDbContext>(DbContextKind.Pooled)
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();
    // .PublishSchemaDefinition(c => c
    //     .SetName("catalogproduct")
    //     .PublishToRedis("Demo", 
    //         sp => sp.GetRequiredService<ConnectionMultiplexer>())); 

var app = builder.Build();

app.MapGraphQL();


// var repo = app.Services.GetService<Repository>();
// repo.Insert();




app.Run();

