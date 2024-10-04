using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Bookings")]
    public class Booking
    {
        [Key]
        [Column("bookingID")]
        public int? BookingID { get; set; }

        [Column("homestayID")]
        public int? HomestayID { get; set; }

        [Column("customerID")]
        public string? CustomerID { get; set; }

        [Column("checkInDate")]
        public DateTime? CheckInDate { get; set; }

        [Column("checkOutDate")]
        public DateTime? CheckOutDate { get; set; }

        [Column("totalAmount")]
        public decimal? TotalAmount { get; set; }

        [Column("bookingStatus")]
        public int? BookingStatus { get; set; }
    }

}
