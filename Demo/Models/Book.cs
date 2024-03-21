namespace Demo.Models;

[GraphQLDescription("Represents a book")]
public class Book
{
    public string Title { get; set; }

    public Author Author { get; set; }
}