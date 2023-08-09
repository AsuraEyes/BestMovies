using MovieServer.Models;

namespace MovieServer.Repository;

public interface IReviewsRepository
{
    Task WriteReviewAsync(Review review);
    Task<IList<Review>> GetAllReviewsAsync(int mediaId);
    Task<IList<Review>> GetAllUserReviewsAsync(string userId);
}