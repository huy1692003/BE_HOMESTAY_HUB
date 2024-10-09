using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_HomeStay_HUB.Repositories
{
    public class CategoryArticleRepository : ICategoryArticleRepository
    {
        private readonly DBContext _context;

        public CategoryArticleRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryArticle>> GetAllCategoryArticles()
        {
            return await _context.CategoryArticles.ToListAsync();
        }

        public async Task<CategoryArticle?> GetCategoryArticleById(int id)
        {
            return await _context.CategoryArticles.FindAsync(id);
        }

        public async Task<bool> AddCategoryArticle(CategoryArticle categoryArticle)
        {
            try
            {
                categoryArticle.CateID = null;
                _context.CategoryArticles.Add(categoryArticle);
                return await _context.SaveChangesAsync() > 0; // Trả về true nếu có thay đổi
            }
            catch
            {
                return false; // Xảy ra lỗi khi thêm
            }
        }

        public async Task<bool> UpdateCategoryArticle(CategoryArticle categoryArticle)
        {
            try
            {
                _context.Entry(categoryArticle).State = EntityState.Modified;
                return await _context.SaveChangesAsync() > 0; // Trả về true nếu có thay đổi
            }
            catch
            {
                return false; // Xảy ra lỗi khi cập nhật
            }
        }

        public async Task<bool> DeleteCategoryArticle(int id)
        {
            try
            {
                var categoryArticle = await _context.CategoryArticles.FindAsync(id);
                if (categoryArticle != null)
                {
                    _context.CategoryArticles.Remove(categoryArticle);
                    return await _context.SaveChangesAsync() > 0; // Trả về true nếu có thay đổi
                }
                return false; // Không tìm thấy dữ liệu
            }
            catch
            {
                return false; // Xảy ra lỗi khi xóa
            }
        }
      

        public bool CategoryArticleExists(int id)
        {
            return _context.CategoryArticles.Any(e => e.CateID == id);
        }
    }
}
