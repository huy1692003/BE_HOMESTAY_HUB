using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        // GET: api/promotion/getAll
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetAllPromotions()
        {
            var promotions = await _promotionService.GetAll();
            return Ok(promotions);
        }

        // GET: api/promotion/getByID/{id}
        [HttpGet("getByID/{id}")]
        public async Task<IActionResult> GetPromotionById(int id)
        {
            var promotion = await _promotionService.GetById(id);
            return promotion != null ? Ok(promotion) : NotFound();
        }

        // POST: api/promotion/create
        [HttpPost("create")]
        public async Task<IActionResult> AddPromotion([FromBody] Promotion promotion)
        {
            if (promotion == null)
            {
                return BadRequest("Promotion không được trống");
            }

            bool state = await _promotionService.Add(promotion);
            return state ?
                CreatedAtAction(nameof(GetPromotionById), new { id = promotion.PrmID }, promotion) :
                BadRequest("Promotion không hợp lệ.");
        }

        // PUT: api/promotion/update
        [HttpPut("update")]
        public async Task<IActionResult> UpdatePromotion([FromBody] Promotion promotion)
        {
            if (promotion == null)
            {
                return BadRequest("Promotion không được để trống");
            }

            bool state = await _promotionService.Update(promotion);
            return state ? NoContent() : BadRequest("Promotion không hợp lệ.");
        }

        // DELETE: api/promotion/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            bool state = await _promotionService.Delete(id);
            return state ? NoContent() : NotFound();
        }
    }
}
