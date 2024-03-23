using Demo.Models;

namespace Demo.DAL;

public class AuthorRepository
{
    public Author GetAuthor(int bookId)
    {
        return new Author
        {
            Name = "John Doe"
        };
    }
}