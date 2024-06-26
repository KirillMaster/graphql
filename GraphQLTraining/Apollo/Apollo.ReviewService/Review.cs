using ApolloGraphQL.HotChocolate.Federation;

namespace Apollo.ReviewService;

[Key("id")]
public class Review
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
}