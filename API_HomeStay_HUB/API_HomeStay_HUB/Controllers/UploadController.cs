using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly string _imagePath;

        public UploadController(IConfiguration configuration)
        {
            _imagePath = Path.Combine(Directory.GetCurrentDirectory(), configuration["ImageSettings:UploadPath"]);

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(_imagePath))
            {
                Directory.CreateDirectory(_imagePath);
            }
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Tạo tên file mới bằng cách sử dụng thời gian hiện tại
            var timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{timeStamp}{fileExtension}";
            var filePath = Path.Combine(_imagePath, fileName);

            // Kiểm tra loại file (có thể điều chỉnh theo nhu cầu)
            var validFileTypes = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            if (!validFileTypes.Contains(fileExtension.ToLowerInvariant()))
            {
                return BadRequest("Invalid file type. Only .jpg, .jpeg, .png, and .gif are allowed.");
            }

            // Lưu file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Trả về đường dẫn của file đã lưu
            return Ok(new { FilePath = "~/assets/upload/image/"+fileName });
        }
    }
}
