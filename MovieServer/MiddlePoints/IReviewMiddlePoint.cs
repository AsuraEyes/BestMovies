using MovieServer.Models;

namespace MovieServer.MiddlePoints;

public interface IReviewMiddlePoint
{
    Task CreateReviewAsync(Review review);
    Task<IList<Review>> GetAllMovieReviewsAsync(int mediaId);
}