using MovieServer.Models;

namespace MovieServer.MiddlePoints;

public interface IReviewMiddlePoint
{
    Task WriteReviewAsync(Review review);
    Task<IList<Review>> GetAllMovieReviewsAsync(int mediaId);
}