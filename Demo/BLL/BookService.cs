using Demo.Models;

namespace Demo.BLL;

public class BookService
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