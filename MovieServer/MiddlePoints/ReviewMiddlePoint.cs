using MovieServer.Models;
using MovieServer.Repository;

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

    public async Task WriteReviewAsync(Review review)
    {
        await reviewsRepository.WriteReviewAsync(review);
    }

    public async Task<IList<Review>> GetAllMovieReviewsAsync(int mediaId)
    {
        reviews = await reviewsRepository.GetAllMovieReviewsAsync(mediaId);
        return reviews;
    }
}