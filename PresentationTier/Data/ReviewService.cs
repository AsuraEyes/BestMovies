using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data;

public class ReviewService : IReviewService
{
    private readonly HttpClient client;
    private const string uri = "https://newbestmoviesapi.azurewebsites.net/";

    public ReviewService()
    {
        client = new HttpClient();
    }
    
    public async Task WriteReviewAsync(Review review)
    {
        Console.WriteLine("test: " + review.Title);
        var newReview = JsonSerializer.Serialize(review);
        HttpContent content = new StringContent(newReview, Encoding.UTF8, "application/json");
        await client.PostAsync("WriteReview", content);
    }
}