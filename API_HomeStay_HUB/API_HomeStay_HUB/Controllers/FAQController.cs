using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly IFAQService _faqService;

        public FAQController(IFAQService faqService)
        {
            _faqService = faqService;
        }

        // GET: api/FAQ
        [HttpGet("getAll")]
        public async Task<IActionResult> GetFAQs()
        {
            var faqs = await _faqService.GetAllFAQ();
            
            return Ok(faqs);
        }

        // GET: api/FAQ/5
        [HttpGet("getbyID/{id}")]
        public async Task<ActionResult<FAQ>> GetFAQ(int id)
        {
            var faq = await _faqService.GetFAQById(id);
            if (faq == null)
            {
                return NotFound();
            }
            return Ok(faq);
        }

        // POST: api/FAQ
        [HttpPost("add")]
        public async Task<ActionResult<FAQ>> PostFAQ(FAQ faq)
        {
            if (faq == null)
            {
                return BadRequest();
            }

            bool success = await _faqService.AddFAQ(faq);
            if (success)
            {
                return CreatedAtAction(nameof(GetFAQ), new { id = faq.FaqID }, faq);
            }

            return BadRequest("Có lỗi rồi");
        }

        // PUT: api/FAQ/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutFAQ(FAQ faq)
        {
            

            bool success = await _faqService.UpdateFAQ(faq);
            if (success)
            {
                return Ok("Cập nhật thành công ");
            }

            return BadRequest("Có lỗi rồi");
        }

        // DELETE: api/FAQ/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFAQ(int id)
        {
            bool success = await _faqService.DeleteFAQ(id);
            if (success)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}

