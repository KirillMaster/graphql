namespace PostService;

public class Query
{
    public Post GetPost(int id) => new Post { Id = id, Title = "Sample Post", Content = "Lorem ipsum dolor sit amet", UserId = 1 };
}