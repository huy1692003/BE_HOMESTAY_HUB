using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [Column("cusID")]
        public string? CusID { get; set; }

        [Column("userID")]
        public string? UserID { get; set; }

        [Column("rentedRoomsTotal")]
        public int? RentedRoomsTotal { get; set; }

        [Column("totalAmountPaID")]
        public decimal? TotalAmountPaid { get; set; }

        public  User? User { get; set; } // Mối quan hệ đến User
    }
}
