using Microsoft.AspNetCore.Mvc;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services.Interface;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenitiesService _service;

        public AmenitiesController(IAmenitiesService service)
        {
            _service = service;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<IActionResult> GetAmenities()
        {
            var amenities = await _service.GetAllAmenitiesAsync();
            return Ok(amenities);
        }

        
        [HttpGet("getByID/{id}")]
        public async Task<ActionResult<Amenities>> GetAmenity(int id)
        {
            var amenity = await _service.GetAmenityByIdAsync(id);

            if (amenity == null)
            {
                return NotFound();
            }

            return Ok(amenity);
        }

        // POST: api/Amenities/add
        [HttpPost("add")]
        public async Task<ActionResult<Amenities>> PostAmenity(Amenities amenity)
        {
            var result = await _service.AddAmenityAsync(amenity);

            if (result)
            {
                return CreatedAtAction(nameof(GetAmenity), new { id = amenity.AmenityID }, amenity);
            }
            return BadRequest("Dữ liệu Amenity không hợp lệ !");
        }

        // PUT: api/Amenities/update
        [HttpPut("update")]
        public async Task<IActionResult> PutAmenity([FromBody] Amenities amenity)
        {
            var result = await _service.UpdateAmenityAsync(amenity);

            if (result)
            {
                return NoContent();
            }
            return NotFound("Sửa Amentity thất bại hãy xem lại data !");
        }

        // DELETE: api/Amenities/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            var result = await _service.DeleteAmenityAsync(id);

            if (result)
            {
                return NoContent();
            }
            return NotFound("Không tìm thấy Amenity");
        }

    }
}
