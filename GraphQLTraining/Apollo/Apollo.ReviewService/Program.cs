using Apollo.ReviewService;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<Review>()
    .AddApolloFederationV2();

var app = builder.Build();

app.MapGraphQL();

app.Run();