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
                Title = "C# in depth.",
                Author = new Author
                {
                    Name = "Jon Skeet"
                }
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