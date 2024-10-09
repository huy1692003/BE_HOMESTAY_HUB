using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Repositories
{
    public class FAQRepository : IFAQRepository
    {

        private readonly DBContext _context;

        public FAQRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FAQ>> GetAllFAQ()
        {
            return await _context.FAQs.ToListAsync();
        }

        public async Task<FAQ?> GetFAQById(int id)
        {
            return await _context.FAQs.FirstOrDefaultAsync(s=>s.FaqID==id);
        }

        public async Task<bool> AddFAQ(FAQ faq)
        {
            await _context.FAQs.AddAsync(faq);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateFAQ(FAQ faq)
        {
            _context.Entry(faq).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteFAQ(int id)
        {
            var faq = _context.FAQs.Find(id);
            if (faq == null)
            {
                return false;
            }
            _context.FAQs.Remove(faq);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
