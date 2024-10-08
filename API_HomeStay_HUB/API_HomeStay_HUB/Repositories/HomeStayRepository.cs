using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Repositories
{
    public class HomeStayRepository:IHomeStayRepository
    {
        private readonly DBContext _dBContext;
        public HomeStayRepository(DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<IEnumerable<HomeStay?>> getHomeStay()
        {
            return await _dBContext.HomeStays.ToListAsync();
        }
        public async Task<IEnumerable<HomeStay?>> searchHomeStay()
        {
            return await _dBContext.HomeStays.ToListAsync();
        }

        public async Task<HomeStay?> getHomeStayByID(int ID)
        {
            var homestay = await _dBContext.HomeStays.FindAsync(ID);
            if (homestay != null)
            {
               
                return homestay;
            }
            return null;
        }

        public async Task<bool> addHomeStay(HomeStay homeStay)
        {
            homeStay.HomestayID = null;
            await _dBContext.HomeStays.AddAsync(homeStay);
            return await _dBContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> updateHomeStay(HomeStay homeStay)
        {
            // Tìm đối tượng HomeStay trong cơ sở dữ liệu
            var existingHomeStay = await _dBContext.HomeStays.FindAsync(homeStay.HomestayID);

            // Nếu đối tượng tồn tại
            if (existingHomeStay != null)
            {
                // Cập nhật các thuộc tính của đối tượng đã được tìm thấy
                _dBContext.Entry(existingHomeStay).CurrentValues.SetValues(homeStay);

                // Lưu thay đổi
                return await _dBContext.SaveChangesAsync() > 0;
            }

            return false; // Trả về false nếu không tìm thấy
        }

        public async Task<bool> deleteHomeStay(int ID)
        {
            var homestay = await _dBContext.HomeStays.FindAsync(ID);
            if (homestay != null)
            {
                _dBContext.HomeStays.Remove(homestay);
                return await _dBContext.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<bool> lockHomeStay(int ID)
        {
            var homestay = await _dBContext.HomeStays.FindAsync(ID);
            if (homestay != null)
            {
                homestay.IsLocked = 1;
                _dBContext.HomeStays.Update(homestay);
                return await _dBContext.SaveChangesAsync() > 0;
            }
            return false;

        }
    }
}
