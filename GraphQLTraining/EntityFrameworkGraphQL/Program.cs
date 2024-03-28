using EntityFrameworkGraphQL.DAL;
using EntityFrameworkGraphQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPooledDbContextFactory<MyDbContext>(
    options => options
        .UseSqlServer("Data Source=(local);Min Pool Size=5;Max Pool Size=3000;Pooling=true;Initial Catalog=Demo;Integrated Security=True;TrustServerCertificate=True",
            b =>
            {
                b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));

builder.Services.AddTransient<Repository>();

builder.Services.AddSingleton(ConnectionMultiplexer.Connect("localhost:6379"));

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<MyDbContext>(DbContextKind.Pooled)
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .PublishSchemaDefinition(c => c
        .SetName("entityframework")
        .PublishToRedis("Demo", 
            sp => sp.GetRequiredService<ConnectionMultiplexer>()));

var app = builder.Build();

app.MapGraphQL();
app.Run();