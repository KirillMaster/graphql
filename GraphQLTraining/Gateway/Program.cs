using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


const string Books = "books";
const string Entityframework = "entityframework";


builder.Services.AddHttpClient(Books, c => c.BaseAddress = new Uri("http://localhost:5034/graphql"));
builder.Services.AddHttpClient(Entityframework, c => c.BaseAddress = new Uri("http://localhost:5070/graphql"));

builder.Services.AddSingleton(ConnectionMultiplexer.Connect("localhost:6379"));

builder.Services.AddGraphQLServer()
   // .AddQueryType(d => d.Name("Query"))
    .AddRemoteSchemasFromRedis("Demo", 
        sp => sp.GetRequiredService<ConnectionMultiplexer>());

var app = builder.Build();

app.MapGraphQL();
app.Run();