using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.AspNetCore;
using UserService;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .ModifyOptions(t => t.EnableTag = false)
    .AddQueryType<Query>()
    .AddType<UserType>();

var app = builder.Build();

app.MapGraphQL();

app.Run();