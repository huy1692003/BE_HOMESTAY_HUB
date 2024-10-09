using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DBContext _context;

        public ArticleRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetArticles_ByCate(int idCate)
        {
            return await _context.Articles.Where(s=>s.CateArtID==idCate).ToListAsync();
        }

        public async Task<Article?> GetArticleById(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<bool> AddArticle(Article article)
        {
            try
            {
                article.ArticleID = null;
                _context.Articles.Add(article);
                return await _context.SaveChangesAsync() > 0; // Trả về true nếu có thay đổi
            }
            catch
            {
                return false; // Xảy ra lỗi khi thêm
            }
        }

        public async Task<bool> UpdateArticle(Article article)
        {
            try
            {
                _context.Entry(article).State = EntityState.Modified;
                return await _context.SaveChangesAsync() > 0; // Trả về true nếu có thay đổi
            }
            catch
            {
                return false; // Xảy ra lỗi khi cập nhật
            }
        }

        public async Task<bool> DeleteArticle(int id)
        {
            try
            {
                var article = await _context.Articles.FindAsync(id);
                if (article != null)
                {
                    _context.Articles.Remove(article);
                    return await _context.SaveChangesAsync() > 0; // Trả về true nếu có thay đổi
                }
                return false; // Không tìm thấy dữ liệu
            }
            catch
            {
                return false; // Xảy ra lỗi khi xóa
            }
        }

        public async Task<IEnumerable<Article>> SearchArticles(string keyword)
        {
            return await _context.Articles
                .Where(a => a.Title!.Contains(keyword) || a.Content!.Contains(keyword))
                .ToListAsync();
        }

        public bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleID == id);
        }
    }
}
