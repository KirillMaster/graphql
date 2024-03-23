using Demo.Models;

namespace Demo.DAL;

public class BookRepository
{
    private List<Book> Books { get; set; }
    
    public BookRepository()
    {
        Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "C# in depth."
            }
        };
    }
    
    public Book AddBook(Book book)
    {
        Books.Add(book);
        return book;
    }

    public List<Book> GetBooks()
    {
        return Books;
    }
}