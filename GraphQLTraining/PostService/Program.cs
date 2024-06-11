var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<PostType>()
    .AddType<ExtendUserType>()
    .AddApolloFederation();

var app = builder.Build();

app.MapGraphQL();

app.Run();

public class Query
{
    public Post GetPost(int id) => new Post { Id = id, Title = "Sample Post", Content = "Lorem ipsum dolor sit amet", UserId = 1 };
}

public class PostType : ObjectType<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
        descriptor.Key("id");
        descriptor.Field(f => f.Id).Type<NonNullType<IdType>>();
        descriptor.Field(f => f.Title).Type<NonNullType<StringType>>();
        descriptor.Field(f => f.Content).Type<NonNullType<StringType>>();
        descriptor.Field(f => f.UserId).Type<NonNullType<IdType>>();
    }
}


public class ExtendUserType : ObjectTypeExtension
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name("User");
        descriptor.Field<List<Post>>( list => list)
            .ResolveWith<Resolvers>(r => r.GetPosts(default!, default!))
            .Type<NonNullType<ListType<NonNullType<PostType>>>>();
    }

    private class Resolvers
    {
        public List<Post> GetPosts([Parent] User user, [Service] IPostService postService)
        {
            return postService.GetPostsByUserId(user.Id);
        }
    }
}

public interface IPostService
{
    List<Post> GetPostsByUserId(int userId);
}

public class PostService : IPostService
{
    public List<Post> GetPostsByUserId(int userId)
    {
        // Реализуйте логику получения постов по userId
        return new List<Post>
        {
            new Post { Id = 1, Title = "Sample Post 1", Content = "Content 1", UserId = userId },
            new Post { Id = 2, Title = "Sample Post 2", Content = "Content 2", UserId = userId }
        };
    }
}