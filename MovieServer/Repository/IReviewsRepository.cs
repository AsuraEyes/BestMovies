using MovieServer.Models;

namespace MovieServer.Repository;

public interface IReviewsRepository
{
    Task WriteReviewAsync(Review review);
    Task<IList<Review>> GetAllMovieReviewsAsync(int mediaId);
    Task<IList<Review>> GetAllUserReviewsAsync(string userId);
}