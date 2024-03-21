using Demo.BLL;
using Demo.Models;

namespace Demo.GraphQL;

public class Mutation
{
    public async Task<Book> AddBook(Book book, [Service] BookService service)
    {
        return service.AddBook(book);
        // Omitted code for brevity
    }
}