using Demo.DAL;
using Demo.Models;

namespace Demo.BLL;

public class BookService
{
    private readonly BookRepository bookRepository;

    public BookService(BookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public Book GetBook()
    {
        return bookRepository.GetBooks().FirstOrDefault();
    }

    public List<Book> GetBooks()
    {
        return bookRepository.GetBooks();
    }
    
    /// <summary>
    /// Adds book to a storage.
    /// </summary>
    /// <param name="book"></param>
    /// <returns>Added book</returns>
    public Book AddBook(Book book)
    {
        return bookRepository.AddBook(book);
    }
}