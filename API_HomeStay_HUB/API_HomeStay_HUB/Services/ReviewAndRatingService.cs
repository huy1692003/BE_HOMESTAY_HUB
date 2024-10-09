using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using API_HomeStay_HUB.Services.Interface;

namespace API_HomeStay_HUB.Services
{
    public class ReviewAndRatingService:IReviewAndRatingService
    {
        private readonly IReviewAndRatingRepository _reviewRes;
        public ReviewAndRatingService(IReviewAndRatingRepository reviewAndRatingService)
        {
            _reviewRes = reviewAndRatingService;
        }
        public async Task<bool> addReview(ReviewAndRating reviewAndRating)
        {
            return await _reviewRes.addReview(reviewAndRating);
        }
        public async Task<IEnumerable<ReviewAndRating?>> getReviews_ByHomeStay(int idHomeStay)
        {
            return await _reviewRes.getReviews_ByHomeStay(idHomeStay);
        }
    }
}
