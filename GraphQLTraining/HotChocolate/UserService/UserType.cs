using HotChocolate.Types;
using UserService;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Field(f => f.Id).Type<NonNullType<IdType>>();
        descriptor.Field(f => f.Name).Type<NonNullType<StringType>>();
        descriptor.Field(f => f.Email).Type<NonNullType<StringType>>();
    }
}