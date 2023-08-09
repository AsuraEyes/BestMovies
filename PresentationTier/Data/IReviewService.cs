using PresentationTier.Models;

namespace PresentationTier.Data;

public interface IReviewService
{
    Task WriteReviewAsync(Review review);
    Task<Review[]> GetAllReviewsAsync(int id);
}