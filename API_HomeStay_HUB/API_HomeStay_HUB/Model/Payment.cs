using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        [Column("paymentID")]
        public int PaymentID { get; set; }

        [Column("bookingID")]
        public int? BookingID { get; set; }

        [Column("ownerID")]
        public string? OwnerID { get; set; }

        [Column("cusID")]
        public string? CusID { get; set; }

        [Column("paymentType")]
        public int? PaymentType { get; set; }

        [Column("notePayment")]
        public string? NotePayment { get; set; }

        [Column("amount")]
        public float? Amount { get; set; }

        [Column("paymentStatus")]
        public int? PaymentStatus { get; set; }

        [Column("paymentMethod")]
        public string? PaymentMethod { get; set; }

        [Column("paymentDate")]
        public DateTime? PaymentDate { get; set; }
       
    }

}
