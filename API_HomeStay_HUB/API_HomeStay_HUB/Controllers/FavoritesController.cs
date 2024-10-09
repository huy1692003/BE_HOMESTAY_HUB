using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesService _faService;
        public FavoritesController(IFavoritesService favoritesService)
        {
            _faService = favoritesService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> addFavorites(int idHomeStay, string idCus)
        {
            if(await _faService.addFavorites(idHomeStay, idCus))
            {
                return Ok("Thêm thành công vào danh sách yêu thích");
            }
            return BadRequest("Dữ liệu không hợp lệ hoặc HomeStay này đã có trong ds");
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> deleteFavorites(int id)
        {
            if (await _faService.deleteFavorites(id))
            {
                return Ok("Xóa thành công khỏi danh sách yêu thích");
            }
            return NotFound();
        }
        [HttpGet("getHomeStayFavorites/{idCus}")]
        public async Task<IActionResult> getHomeStay_Favorites(string idCus)
        {
            return Ok(await _faService.getHomeStay_Favorites(idCus));
        }
    }
}
