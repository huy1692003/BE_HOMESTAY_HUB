using API_HomeStay_HUB.Repositories.Interfaces;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryArticleController : ControllerBase
    {
        private readonly ICategoryArticleService _categoryArticleService;
        public CategoryArticleController(ICategoryArticleService categoryArticleService)
        {
            _categoryArticleService = categoryArticleService;
        }
        [HttpGet("getAll")]       
        
        public async Task<IActionResult> GetAllCategoryArticles()
        {
            return Ok(await _categoryArticleService.GetAllCategoryArticles());
        }
        [HttpGet("getByID/{id}")]
        public async Task<IActionResult> GetCategoryArticleById(int id)
        {
            var cate=await _categoryArticleService.GetCategoryArticleById(id);
            if (cate == null)
            {
                return NotFound();
            }
            return Ok(cate);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCategoryArticle(CategoryArticle categoryArticle)
        {
            if (categoryArticle == null)
            {
                return BadRequest("Dữ liệu không được để trống");
            }
            var checkAdd= await _categoryArticleService.AddCategoryArticle(categoryArticle);
            if (checkAdd)
            {
                return CreatedAtAction(nameof(GetCategoryArticleById),new {id=categoryArticle.CateID}, categoryArticle);
            }
            return BadRequest("Dữ liệu không hợp lệ ");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategoryArticle(CategoryArticle categoryArticle)
        {
            if(await _categoryArticleService.UpdateCategoryArticle(categoryArticle))
            {
                return Ok("Cập nhật thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategoryArticle(int id)
        {
            if (await _categoryArticleService.DeleteCategoryArticle(id))
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }
       
    }
}
