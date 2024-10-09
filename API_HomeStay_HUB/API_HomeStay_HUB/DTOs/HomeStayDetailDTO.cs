using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.DTOs
{
    public class HomeStayDetailDTO
    {
        public HomeStay? HomeStay { get; set; }
        public DetailHomeStay? DetailHomeStay { get; set; }
        public List<HomeStayAmenities>? HomeStayAmenities { get; set; }
        public List<Amenities>? Amenities { get; set; }
    }
}
