using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.AspNetCore;
using PostService;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .ModifyOptions(t => t.EnableTag = false)
    .AddQueryType<Query>()
    .AddType<PostType>();

var app = builder.Build();

app.MapGraphQL();

app.Run();