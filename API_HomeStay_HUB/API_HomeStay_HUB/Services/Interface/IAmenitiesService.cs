using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Services.Interface
{
    public interface IAmenitiesService
    {
        Task<IEnumerable<Amenities>> GetAllAmenitiesAsync();
        Task<Amenities?> GetAmenityByIdAsync(int id);
        Task<bool> AddAmenityAsync(Amenities amenity);
        Task<bool> UpdateAmenityAsync(Amenities amenity);
        Task<bool> DeleteAmenityAsync(int id);
        bool AmenityExists(int id);
    }
}
