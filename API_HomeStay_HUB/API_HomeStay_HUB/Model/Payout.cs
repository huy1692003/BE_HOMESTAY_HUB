using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Payouts")]
    public class Payout
    {
        [Key]
        [Column("payoutID")]
        public int PayoutID { get; set; }

        [Column("ownerID")]
        public string? OwnerID { get; set; }

        [Column("cusID")]
        public string? CusID { get; set; }

        [Column("totalEarnings")]
        public float? TotalEarnings { get; set; }

        [Column("payoutAmount")]
        public float? PayoutAmount { get; set; }

        [Column("payoutStatus")]
        public string? PayoutStatus { get; set; }

        [Column("payoutDate")]
        public DateTime? PayoutDate { get; set; } = DateTime.Now;

        [Column("payoutMethod")]
        public string? PayoutMethod { get; set; }

        [Column("createdAt")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Column("createdBy")]
        public int? CreatedBy { get; set; }

       
    }

}
