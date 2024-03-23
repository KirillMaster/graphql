using Demo.DAL;

namespace Demo.Models;

[GraphQLDescription("Represents a book")]
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    public Author GetAuthors([Parent] Book parent, [Service] AuthorRepository repository)
    {
        return repository.GetAuthor(parent.Id);
    }
}