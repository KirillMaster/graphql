using ApolloGraphQL.HotChocolate.Federation;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<UserType>()
    .AddType<ExtendPostType>()
    .AddApolloFederation();

var app = builder.Build();

app.MapGraphQL();

app.Run();

public class Query
{
    public User GetUser(int id) => new User { Id = id, Name = "John Doe" };
}

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Key("id");
        descriptor.Field(f => f.Id).Type<NonNullType<IdType>>();
        descriptor.Field(f => f.Name).Type<NonNullType<StringType>>();
    }
}



public class ExtendPostType : ObjectTypeExtension
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name("Post");
        descriptor.Field<Post>(post => post.UserId)
            .Name("user")
            .ResolveWith<Resolvers>(r => r.GetUser(default, default))
            .Type<NonNullType<UserType>>();
    }

   
}

public class Resolvers
{
    public User GetUser([Parent] Post post, [Service] IUserService userService)
    {
        return userService.GetUserById(post.UserId);
    }
}

public interface IUserService
{
    User GetUserById(int userId);
}

public class UserService : IUserService
{
    public User GetUserById(int userId)
    {
        // Реализуйте логику получения пользователя по userId
        return new User { Id = userId, Name = "John Doe" };
    }
}