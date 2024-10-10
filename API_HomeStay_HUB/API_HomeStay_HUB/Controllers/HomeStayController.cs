using API_HomeStay_HUB.DTOs;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeStayController : ControllerBase
    {
        private readonly IHomeStayService _homeStayService;

        public HomeStayController(IHomeStayService homeStayService)
        {
            _homeStayService = homeStayService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetHomeStay()
        {
            var result = await _homeStayService.getHomeStay();
            return Ok(result);
        }

        [HttpPost("searchByCustomer")]

        public async Task<IActionResult> searchHomeStay([FromBody]SearchHomeStayDTO search,[FromQuery] PaginateDTO paginate)
        {
            var result = await _homeStayService.searchHomeStay(search,paginate);
            return Ok(result);
        }

        [HttpGet("getByID/{id}")]
        public async Task<IActionResult> GetHomeStayByID(int id)
        {
            var result = await _homeStayService.getHomeStayByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddHomeStay([FromBody] HomeStayReqDTO homeStayReq)
        {
            if (homeStayReq == null)
            {
                return BadRequest("Dữ liệu HomeStay không được trống");
            }
            var isAdded = await _homeStayService.addHomeStay(homeStayReq);
            if (isAdded == true)
            {
                return CreatedAtAction(nameof(GetHomeStayByID), new { id = homeStayReq.HomeStay!.HomestayID }, homeStayReq);
            }
            return BadRequest("Dữ liệu HomeStay không hợp lệ");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateHomeStay([FromBody] HomeStayReqDTO homeStayReq)
        {
            if (await _homeStayService.updateHomeStay(homeStayReq))
            {
                return Ok("Cập nhật thành công HomeStay");
            }
            return BadRequest("Dữ liệu HomeStay cập nhật không hợp lệ");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeStay(int id)
        {
            var isDeleted = await _homeStayService.deleteHomeStay(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok("Xóa thành công HomeStay");
        }

        [HttpPost("lock/{id}")]
        public async Task<IActionResult> LockHomeStay(int id)
        {
            var isLocked = await _homeStayService.lockHomeStay(id);
            if (!isLocked)
            {
                return NotFound();
            }
            return Ok("Lock sucess");
        }
    }
}
