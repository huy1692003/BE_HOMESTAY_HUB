using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services.Interface;
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

        [HttpGet("search")]
        public async Task<IActionResult> SearchHomeStay()
        {
            var result = await _homeStayService.searchHomeStay();
            return Ok(result);
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> AddHomeStay([FromBody] HomeStay homeStay)
        {
            if (homeStay == null)
            {
                return BadRequest("Homestay data is required.");
            }
            var isAdded = await _homeStayService.addHomeStay(homeStay);
            if (!isAdded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding homestay.");
            }
            return Ok("add HomeStay success");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateHomeStay([FromBody] HomeStay homeStay)
        {
            if (homeStay == null || homeStay.HomestayID == null)
            {
                return BadRequest("Homestay data with ID is required.");
            }
            var isUpdated = await _homeStayService.updateHomeStay(homeStay);
            if (!isUpdated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating homestay.");
            }
            return Ok("update success");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeStay(int id)
        {
            var isDeleted = await _homeStayService.deleteHomeStay(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok("delete success");
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
