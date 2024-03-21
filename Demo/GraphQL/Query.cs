using Demo.Models;

namespace Demo.GraphQL;

public class Query
{
    public Book GetBook()
    {
        return new Book
        {
            Title = "C# in depth.",
            Author = new Author
            {
                Name = "Jon Skeet"
            }
        };
    }
}
