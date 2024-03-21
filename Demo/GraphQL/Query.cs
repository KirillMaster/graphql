using Demo.BLL;
using Demo.Models;

namespace Demo.GraphQL;

public class Query
{
    public Book GetBook([Service] BookService bookService)
    {
        return bookService.GetBook();
    }

    public List<Book> GetBooks([Service] BookService bookService)
    {
        return bookService.GetBooks();
    }
}
