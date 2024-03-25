using EntityFrameworkGraphQL.DAL;
using EntityFrameworkGraphQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPooledDbContextFactory<MyDbContext>(
    options => options
        .UseSqlServer("Data Source=(local);Min Pool Size=5;Max Pool Size=3000;Pooling=true;Initial Catalog=Demo;Integrated Security=True;TrustServerCertificate=True",
            b =>
            {
                b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));

builder.Services.AddTransient<Repository>();

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<MyDbContext>(DbContextKind.Pooled)
    .AddQueryType<Query>()
    .AddProjections();

var app = builder.Build();

app.MapGraphQL();
app.Run();