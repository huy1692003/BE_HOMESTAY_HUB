using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Services.Interface
{
    public interface IReviewAndRatingService
    {
        Task<bool> addReview(ReviewAndRating reviewAndRating);
        Task<IEnumerable<ReviewAndRating?>> getReviews_ByHomeStay(int idHomeStay);
    }
}
