using System.Collections.Generic;
using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Repositories.Interfaces
{
    public interface ICategoryArticleRepository
    {
        Task<IEnumerable<CategoryArticle>> GetAllCategoryArticles();
        Task<CategoryArticle?> GetCategoryArticleById(int id);
        Task<bool> AddCategoryArticle(CategoryArticle categoryArticle);
        Task<bool> UpdateCategoryArticle(CategoryArticle categoryArticle);
        Task<bool> DeleteCategoryArticle(int id);       
        bool CategoryArticleExists(int id);
    }
}
