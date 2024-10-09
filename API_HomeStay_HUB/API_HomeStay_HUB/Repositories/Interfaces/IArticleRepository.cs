using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticles();
        Task<IEnumerable<Article>> GetArticles_ByCate(int idCate);
        Task<Article?> GetArticleById(int id);
        Task<bool> AddArticle(Article article);
        Task<bool> UpdateArticle(Article article);
        Task<bool> DeleteArticle(int id);
        Task<IEnumerable<Article>> SearchArticles(string keyword);
        bool ArticleExists(int id);
    }
}
