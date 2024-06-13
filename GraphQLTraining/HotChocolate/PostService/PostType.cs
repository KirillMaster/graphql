using HotChocolate.Types;
using PostService;

public class PostType : ObjectType<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
        descriptor.Field(f => f.Id).Type<NonNullType<IdType>>();
        descriptor.Field(f => f.Title).Type<NonNullType<StringType>>();
        descriptor.Field(f => f.Content).Type<NonNullType<StringType>>();
        descriptor.Field(f => f.UserId).Type<NonNullType<IdType>>();
    }
}