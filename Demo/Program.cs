using Demo.BLL;
using Demo.DAL;
using Demo.GraphQL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<BookRepository>();
builder.Services.AddSingleton<AuthorRepository>();
builder.Services.AddTransient<BookService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();


var app = builder.Build();

app.MapGraphQL();

app.Run();