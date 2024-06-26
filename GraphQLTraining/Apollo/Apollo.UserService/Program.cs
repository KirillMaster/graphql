var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddDocumentFromFile("./Schema.graphql")
    .AddApolloFederationV2()
    .AddResolver<Query>()
    // .AddType<UserType>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

var app = builder.Build();

app.MapGraphQL();

app.Run();