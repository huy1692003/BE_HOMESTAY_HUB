using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewAndRatingController : ControllerBase
    {
        private readonly IReviewAndRatingService _reviewAndRatingService;
        public ReviewAndRatingController(IReviewAndRatingService reviewAndRatingService)
        {
            _reviewAndRatingService = reviewAndRatingService;
        }
        [HttpGet("getReviewByHomeStay/{id}")]
        public async Task<IActionResult> getReviewByHomeStay(int id)
        {
            return Ok(await _reviewAndRatingService.getReviews_ByHomeStay(id));
        }

        [HttpPost("add")]
        public async Task<IActionResult> addReviewAndRating([FromBody] ReviewAndRating rv)
        {
            if (await _reviewAndRatingService.addReview(rv))
            {
                return Ok("Thêm đánh giá thành công");
            }
            return BadRequest("Dữ liệu đánh giá không hợp lệ");
        }
    }
}
