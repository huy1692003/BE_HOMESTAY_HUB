using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HomeStay_HUB.Model
{
    [Table("Bookings")]
    public class Booking
    {
        [Key]
        [Column("bookingID")]
        public int BookingID { get; set; }

        [Column("cusID")]
        public string? CustomerID { get; set; }

        [Column("ownerID")]
        public string? OwnerID { get; set; }

        [Column("homestayID")]
        public int? HomeStayID { get; set; }

        [Column("checkInDate")]
        public DateOnly? CheckInDate { get; set; }

        [Column("checkOutDate")]
        public DateOnly? CheckOutDate { get; set; }

        [Column("numberOfGuests")]
        public int? NumberOfGuests { get; set; }

        [Column("totalPrice")]
        public double? TotalPrice { get; set; }

        [Column("paymentMethod")]
        public string? PaymentMethod { get; set; }

        [Column("discountPrice")]
        public double? DiscountPrice { get; set; }

        [Column("discountCode")]
        public string? DiscountCode { get; set; }

        [Column("originalPrice")]
        public double? OriginalPrice { get; set; }

        [Column("guestList")]
        public string? GuestList { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("isConfirm")]
        public int? IsConfirm { get; set; }

        [Column("isCancel")]
        public int? IsCancel { get; set; }
        [Column("reasonCancel")]
        public string? ReasonCancel { get; set; }

        [Column("bookingTime")]
        public DateTime? BookingTime { get; set; } = DateTime.Now;
    }
}
