namespace UserService;

public class Query
{
    public User GetUser(int id) => new User { Id = id, Name = "John Doe", Email = "john.doe@example.com" };
}