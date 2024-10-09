using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using API_HomeStay_HUB.Services.Interface;

namespace API_HomeStay_HUB.Services
{
    public class FAQService : IFAQService
    {
        private readonly IFAQRepository _repository;

        public FAQService(IFAQRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FAQ>> GetAllFAQ()
        {
            return await _repository.GetAllFAQ();
        }

        public async Task<FAQ> GetFAQById(int id)
        {
            return await _repository.GetFAQById(id);
        }

        public async Task<bool> AddFAQ(FAQ faq)
        {
            return await _repository.AddFAQ(faq);
        }

        public async Task<bool> UpdateFAQ(FAQ faq)
        {
            return await _repository.UpdateFAQ(faq);
        }

        public async Task<bool> DeleteFAQ(int id)
        {
            return await _repository.DeleteFAQ(id);
        }
    }
}
