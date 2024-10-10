namespace API_HomeStay_HUB.DTOs
{
    public class SearchHomeStayDTO
    {
        public string Location { get; set; } = "";
        public int NumberofGuest { get; set; } = 1;
        public DateOnly DateIn { get; set; }
        public DateOnly DateOut { get; set; }
    }
}
