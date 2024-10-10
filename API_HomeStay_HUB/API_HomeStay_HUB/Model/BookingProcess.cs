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

        [Column("paymentTime")]
        public DateTime? PaymentTime { get; set; } 

        [Column("checkInTime")]
        public DateTime? CheckInTime { get; set; } 

        [Column("checkOutTime")]
        public DateTime? CheckOutTime { get; set; }

        [Column("completeStatus")]
        public string? CompleteStatus { get; set; }

        [Column("stepOrder")]
        public int? StepOrder { get; set; }

        [Column("createdAt")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Column("updatedAt")]
        public DateTime? UpdatedAt { get; set; }    

    }

}
