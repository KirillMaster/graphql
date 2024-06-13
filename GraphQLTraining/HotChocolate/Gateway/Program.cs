using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Stitching;
using HotChocolate.Types;
using HotChocolate.Execution;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHttpClient("userService", c => c.BaseAddress = new Uri("http://localhost:5150/graphql"));
builder.Services
    .AddHttpClient("postService", c => c.BaseAddress = new Uri("http://localhost:5072/graphql"));

builder.Services
    .AddGraphQLServer()
    .AddRemoteSchema("userService")
    .AddRemoteSchema("postService")
    .AddDocumentFromFile("Schema.graphql")
    .ModifyOptions(t => t.EnableTag = false)
    .AddTypeExtensionsFromString(@"
        extend type User {
            posts: [Post]
        }

        extend type Post {
            user: User
        }
    ")
    .ModifyRequestOptions(opt =>
    {
        opt.IncludeExceptionDetails = true;
    })
    .AddErrorFilter(error =>
    {
        if (error.Exception is HttpRequestException)
        {
            return ErrorBuilder.New()
                .SetMessage("A subgraph service is currently unavailable. Partial results returned.")
                .SetCode("SERVICE_UNAVAILABLE")
                .Build();
        }
        return error;
    });

var app = builder.Build();

app.MapGraphQL();

app.Run();