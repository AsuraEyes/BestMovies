using MovieServer.Models;

namespace MovieServer.DAO;

public interface IReviewsRepository
{
    Task CreateReviewAsync(Review review);
    Task<IList<Review>> GetAllMovieReviewsAsync(int mediaId);
    Task<IList<Review>> GetAllUserReviewsAsync(string userId);
}