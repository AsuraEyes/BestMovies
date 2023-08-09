using MovieServer.Models;
using MovieServer.Repository;

namespace MovieServer.MiddlePoints;

public class ReviewMiddlePoint : IReviewMiddlePoint
{
    private readonly IReviewsRepository reviewsRepository;
    private readonly IUserRepository userRepository;
    private IList<Review> reviews;

    public ReviewMiddlePoint(IReviewsRepository reviewsRepository, IUserRepository userRepository)
    {
        this.reviewsRepository = reviewsRepository;
        this.userRepository = userRepository;
        reviews = new List<Review>();
    }

    public async Task WriteReviewAsync(Review review)
    {
        var user = await userRepository.GetUserAsync(review.Email);
        review.Username = user.Username;
        await reviewsRepository.WriteReviewAsync(review);
    }

    public async Task<IList<Review>> GetAllReviewsAsync(int mediaId)
    {
        reviews = await reviewsRepository.GetAllReviewsAsync(mediaId);
        return reviews;
    }
}