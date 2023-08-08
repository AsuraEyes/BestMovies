using MovieServer.Models;

namespace MovieServer.DAO;

public interface IReviewsRepository
{
    Task WriteReviewAsync(Review review);
    Task<IList<Review>> GetAllMovieReviewsAsync(int mediaId);
    Task<IList<Review>> GetAllUserReviewsAsync(string userId);
}