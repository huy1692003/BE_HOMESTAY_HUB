using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.DTOs
{
    public class HomeStayReqDTO
    {
        public HomeStay? HomeStay { get; set; }
        public int[]? ListAmenities { get; set; }
        public DetailHomeStay? DetailHomeStay { get; set; }
    }
}
