using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Repositories
{
    public class ReviewAndRatingRepository:IReviewAndRatingRepository
    {
        private readonly DBContext _dBContext;
        public ReviewAndRatingRepository(DBContext dbContext)
        {
            _dBContext = dbContext;
        }
        public async Task<bool> addReview(ReviewAndRating reviewAndRating)
        {
            await _dBContext.ReviewAndRatings.AddAsync(reviewAndRating);
            return await _dBContext.SaveChangesAsync()>0;
        }
        public async Task<IEnumerable<ReviewAndRating?>> getReviews_ByHomeStay(int idHomeStay)
        {
            return await _dBContext.ReviewAndRatings.Where(r=>r.HomestayID==idHomeStay).ToListAsync();
        }
    }
}
