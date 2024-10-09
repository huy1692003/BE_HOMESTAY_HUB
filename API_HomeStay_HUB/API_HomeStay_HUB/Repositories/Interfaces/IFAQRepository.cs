using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Repositories.Interfaces
{
    public interface IFAQRepository
    {
        Task<IEnumerable<FAQ>> GetAllFAQ();
        Task<FAQ?> GetFAQById(int id);
        Task<bool> AddFAQ(FAQ faq);
        Task<bool> UpdateFAQ(FAQ faq);
        Task<bool> DeleteFAQ(int id);
    }
}
