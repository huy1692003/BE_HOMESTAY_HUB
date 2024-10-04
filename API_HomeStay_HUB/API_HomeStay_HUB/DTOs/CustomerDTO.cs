using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.DTOs
{
    public class CustomerDTO
    {
        public string? UserID { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public int? AccountStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Status { get; set; }
        public int? Gender { get; set; }
        public string? CusID { get; set; }
        public int? RentedRoomsTotal { get; set; }
        public decimal? TotalAmountPaid { get; set; }
    }
}
