
using ApolloGraphQL.HotChocolate.Federation;

[Key("id")]
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}