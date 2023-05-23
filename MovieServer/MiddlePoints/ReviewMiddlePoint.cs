using MovieServer.DAO;
using MovieServer.Models;

namespace MovieServer.MiddlePoints;

public class ReviewMiddlePoint : IReviewMiddlePoint
{
    private readonly IReviewsRepository reviewsRepository;
    private IList<Review> reviews;

    public ReviewMiddlePoint(IReviewsRepository reviewsRepository)
    {
        this.reviewsRepository = reviewsRepository;
        reviews = new List<Review>();
    }

    public async Task CreateReviewAsync(Review review)
    {
        await reviewsRepository.CreateReviewAsync(review);
    }

    public async Task<IList<Review>> GetAllMovieReviewsAsync(int mediaId)
    {
        reviews = await reviewsRepository.GetAllMovieReviewsAsync(mediaId);
        return reviews;
    }
}