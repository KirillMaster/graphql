using Demo.BLL;
using Demo.DAL;
using Demo.GraphQL;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<BookRepository>();
builder.Services.AddSingleton<AuthorRepository>();
builder.Services.AddTransient<BookService>();

builder.Services.AddSingleton(ConnectionMultiplexer.Connect("localhost:6379"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .InitializeOnStartup()
    .PublishSchemaDefinition(c => c
        .SetName("books")
        .PublishToRedis("Demo", 
            sp => sp.GetRequiredService<ConnectionMultiplexer>()));



var app = builder.Build();

app.MapGraphQL();

app.Run();