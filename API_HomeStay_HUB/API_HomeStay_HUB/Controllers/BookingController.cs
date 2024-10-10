using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("getBookingDateExisted")]
        public async Task<IActionResult> getBookingDates(int idHomeStay)
        {
            return Ok(await _bookingService.getBookingDates(idHomeStay));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Dữ liệu đặt phòng là bắt buộc.");
            }

            var result = await _bookingService.createBooking(booking);
            if (result)
            {
                return Ok("Đặt phòng thành công.");
            }
            return BadRequest("Không thể tạo đặt phòng.");
        }


        [HttpPut("confirm/{idBooking}")]
        public async Task<IActionResult> ConfirmBooking(int idBooking)
        {
            var result = await _bookingService.confirmBooking(idBooking);
            if (result)
            {
                return Ok("Đặt phòng đã được xác nhận thành công.");
            }
            return BadRequest("Không thể xác nhận đặt phòng.");
        }


        [HttpPut("cancel/{idBooking}")]
        public async Task<IActionResult> CancelBooking(int idBooking, [FromQuery] string reasonCancel)
        {
            if (string.IsNullOrEmpty(reasonCancel))
            {
                return BadRequest("Lý do hủy đặt phòng là bắt buộc.");
            }

            var result = await _bookingService.cancelBooking(idBooking, reasonCancel);
            if (result)
            {
                return Ok("Đặt phòng đã được hủy thành công.");
            }
            return BadRequest("Không thể hủy đặt phòng.");
        }

    }
}
