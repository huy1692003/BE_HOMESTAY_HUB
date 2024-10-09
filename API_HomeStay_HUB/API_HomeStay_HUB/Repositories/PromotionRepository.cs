using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly DBContext _db;

        public PromotionRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Promotion>> GetAll()
        {
            return await _db.Promotions.ToListAsync();
        }

        public async Task<Promotion?> GetById(int ID)
        {
            return await _db.Promotions.FindAsync(ID);
        }

        public async Task<bool> Add(Promotion prm)
        {
            await _db.Promotions.AddAsync(prm);
            return await _db.SaveChangesAsync() > 0; // Trả về true nếu thêm thành công
        }

        public async Task<bool> Update(Promotion prm)
        {
            _db.Promotions.Update(prm);
            return await _db.SaveChangesAsync() > 0; // Trả về true nếu cập nhật thành công
        }

        public async Task<bool> Delete(int ID)
        {
            var promotion = await _db.Promotions.FindAsync(ID);
            if (promotion != null)
            {
                _db.Promotions.Remove(promotion);
                return await _db.SaveChangesAsync() > 0; // Trả về true nếu xóa thành công
            }
            return false; // Trả về false nếu không tìm thấy để xóa
        }
    }
}
