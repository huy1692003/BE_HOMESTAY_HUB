using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Repositories
{
    public class AmenitiesRepository : IAmenitiesRepository
    {
        private readonly DBContext _context;

        public AmenitiesRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Amenities>> GetAllAmenitiesAsync()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities?> GetAmenityByIdAsync(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        public async Task<bool> AddAmenityAsync(Amenities amenity)
        {
            _context.Amenities.Add(amenity);
            return await _context.SaveChangesAsync() > 0;  // Trả về true nếu thành công
        }

        public async Task<bool> UpdateAmenityAsync(Amenities amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;  // Trả về true nếu thành công
        }

        public async Task<bool> DeleteAmenityAsync(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return false;
            }

            _context.Amenities.Remove(amenity);
            return await _context.SaveChangesAsync() > 0;  // Trả về true nếu thành công
        }

        public bool AmenityExists(int id)
        {
            return _context.Amenities.Any(e => e.AmenityID == id);
        }
    }
}
