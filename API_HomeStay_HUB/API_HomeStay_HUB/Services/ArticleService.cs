using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using API_HomeStay_HUB.Services.Interface;

namespace API_HomeStay_HUB.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repository;

        public ArticleService(IArticleRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Article>> GetAllArticles()
        {
            return _repository.GetAllArticles();
        }

        public Task<Article?> GetArticleById(int id)
        {
            return _repository.GetArticleById(id);
        }
        public Task<IEnumerable<Article>> GetArticles_ByCate(int idCate)
        {
            return _repository.GetArticles_ByCate(idCate);
        }

        public Task<bool> AddArticle(Article article)
        {
            return _repository.AddArticle(article);
        }

        public Task<bool> UpdateArticle(Article article)
        {
            return _repository.UpdateArticle(article);
        }

        public Task<bool> DeleteArticle(int id)
        {
            return _repository.DeleteArticle(id);
        }

        public Task<IEnumerable<Article>> SearchArticles(string keyword)
        {
            return _repository.SearchArticles(keyword);
        }

        public bool ArticleExists(int id)
        {
            return _repository.ArticleExists(id);
        }
    }
}
