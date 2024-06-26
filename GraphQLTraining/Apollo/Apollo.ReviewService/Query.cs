using Apollo.ReviewService;

public class Query
{
    private static List<Review> reviews = new List<Review>
    {
        new Review { Id = 1, UserId = 1, Content = "Review 1 for User 1" },
        new Review { Id = 2, UserId = 1, Content = "Review 2 for User 1" },
        new Review { Id = 3, UserId = 2, Content = "Review 1 for User 2" }
    };

    public IEnumerable<Review> GetReviewsByUserId(int userId) => reviews.Where(r => r.UserId == userId);
}