using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("BookingProcess")]
    public class BookingProcess
    {
        [Key]
        [Column("processID")]
        public int ProcessID { get; set; }

        [Column("bookingID")]
        public int? BookingID { get; set; }

        [Column("approvalStatus")]
        public int? ApprovalStatus { get; set; } = 0;

        [Column("paymentStatus")]
        public int? PaymentStatus { get; set; } = 0;

        [Column("checkInStatus")]
        public int? CheckInStatus { get; set; } = 0;

        [Column("checkOutStatus")]
        public int? CheckOutStatus { get; set; } = 0;

        [Column("stepOrder")]
        public int? StepOrder { get; set; }

        [Column("createdAt")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Column("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

      
    }

}
