using EntityFrameworkGraphQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MyDbContext>(
    options => options
        .UseSqlServer("Data Source=(local);Min Pool Size=5;Max Pool Size=3000;Pooling=true;Initial Catalog=Demo;Integrated Security=True;TrustServerCertificate=True",
            b =>
            {
                b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .RegisterDbContext<MyDbContext>();

var app = builder.Build();

app.MapGraphQL();
app.Run();