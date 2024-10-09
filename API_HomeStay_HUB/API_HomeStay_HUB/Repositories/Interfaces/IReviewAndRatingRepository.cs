using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Repositories.Interfaces
{
    public interface IReviewAndRatingRepository
    {
        Task<bool> addReview(ReviewAndRating reviewAndRating);
        Task<IEnumerable<ReviewAndRating?>> getReviews_ByHomeStay(int idHomeStay);
    }
}
