using Demo.BLL;
using Demo.GraphQL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<BookService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();


var app = builder.Build();

app.MapGraphQL();

app.Run();