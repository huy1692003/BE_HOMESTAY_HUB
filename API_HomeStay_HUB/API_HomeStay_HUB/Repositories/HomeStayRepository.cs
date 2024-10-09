using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.DTOs;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Repositories
{
    public class HomeStayRepository : IHomeStayRepository
    {
        private readonly DBContext _dBContext;
        public HomeStayRepository(DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<IEnumerable<HomeStayResDTO?>> getHomeStay()
        {
            var data = await (from HomeStay in _dBContext.HomeStays
                              join DetailHomeStay in _dBContext.DetailHomeStays
                              on HomeStay.HomestayID equals DetailHomeStay.HomestayID
                              select new HomeStayResDTO
                              {
                                  HomeStay = HomeStay,
                                  DetailHomeStay = DetailHomeStay,
                              }).ToListAsync();
            return data;
        }
        //Chưa fix
        public async Task<IEnumerable<HomeStayResDTO?>> searchHomeStay()
        {
            var data = await (from HomeStay in _dBContext.HomeStays
                              join DetailHomeStay in _dBContext.DetailHomeStays
                              on HomeStay.HomestayID equals DetailHomeStay.HomestayID
                              select new HomeStayResDTO
                              {
                                  HomeStay = HomeStay,
                                  DetailHomeStay = DetailHomeStay,
                              }).ToListAsync();
            return data;
        }

        public async Task<HomeStayDetailDTO?> getHomeStayByID(int ID)
        {
            var data = await (from hs in _dBContext.HomeStays
                              join dtH in _dBContext.DetailHomeStays
                              on hs.HomestayID equals dtH.HomestayID
                              where hs.HomestayID == ID
                              select new HomeStayDetailDTO
                              {
                                  HomeStay = hs,  // Thông tin Homestay
                                  DetailHomeStay = dtH,  // Thông tin chi tiết homestay

                                  // Lấy danh sách HomeStayAmenities (tối ưu: không cần check lại ID)
                                  HomeStayAmenities = (from hsA in _dBContext.HomeStayAmenities
                                                       where hsA.HomestayID == hs.HomestayID
                                                       select hsA).ToList(),

                                  // Lấy danh sách Amenities dựa trên HomeStayAmenities
                                  Amenities = (from hsA in _dBContext.HomeStayAmenities
                                               join amen in _dBContext.Amenities
                                               on hsA.AmenityID equals amen.AmenityID
                                               where hsA.HomestayID == hs.HomestayID
                                               select amen).ToList()
                              }).FirstOrDefaultAsync();

            return data;
        }


        public async Task<bool> addHomeStay(HomeStayReqDTO req)
        {
            req.HomeStay!.HomestayID = null;
            //Tạo HomeStay và trả về HomeStay đó
            var hsCreated = await _dBContext.HomeStays.AddAsync(req.HomeStay);
            await _dBContext.SaveChangesAsync();

            if (hsCreated.Entity != null)
            {
                //Tạo chi tiết HomeStay đó
                req.DetailHomeStay!.HomestayID = hsCreated.Entity.HomestayID;
                await _dBContext.DetailHomeStays.AddAsync(req.DetailHomeStay);

                //Tạo danh sách các tiện nghi liên Quan đến HomeStay đó 
                foreach (var idAmen in req.ListAmenities!)
                {
                    var homeStayAmenity = new HomeStayAmenities
                    {
                        HomestayID = hsCreated.Entity.HomestayID,
                        AmenityID = idAmen
                    };
                    await _dBContext.HomeStayAmenities.AddAsync(homeStayAmenity);
                }
                return await _dBContext.SaveChangesAsync() > 0;

            }
            return false;

        }


        public async Task<bool> updateHomeStay(HomeStayReqDTO req)
        {
            try
            {
                // Tìm đối tượng HomeStay trong cơ sở dữ liệu
                var existingHomeStay = await _dBContext.HomeStays.FindAsync(req.HomeStay!.HomestayID);
                _dBContext.Entry(existingHomeStay!).CurrentValues.SetValues(req.HomeStay);

                if (req.DetailHomeStay != null)
                {
                    //Cập nhật chi tiết Homestay
                    var existingDetail = await _dBContext.DetailHomeStays.FirstOrDefaultAsync(d => d.HomestayID == req.HomeStay.HomestayID);
                    _dBContext.Entry(existingDetail!).CurrentValues.SetValues(req.DetailHomeStay);
                    
                }

                // Cập nhật các tiện nghi của HomeStay
                if (req.ListAmenities != null && req.ListAmenities.Any())
                {
                    // Xóa tất cả tiện nghi cũ trước khi thêm mới
                    var existingAmenities = await _dBContext.HomeStayAmenities
                                                             .Where(hsa => hsa.HomestayID == req.HomeStay.HomestayID)
                                                             .ToListAsync();

                    _dBContext.HomeStayAmenities.RemoveRange(existingAmenities);

                    // Thêm các tiện nghi mới
                    var newHomeStayAmenities = req.ListAmenities.Select(amenityID => new HomeStayAmenities
                    {
                        HomestayID = req.HomeStay.HomestayID,
                        AmenityID = amenityID
                    }).ToList();

                    await _dBContext.HomeStayAmenities.AddRangeAsync(newHomeStayAmenities);
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                return await _dBContext.SaveChangesAsync()>0;
            }
            catch (Exception ex)
            {
                
                return false;
            }
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
