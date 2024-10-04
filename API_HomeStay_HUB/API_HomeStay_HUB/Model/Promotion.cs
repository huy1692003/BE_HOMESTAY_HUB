using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Promotions")]
    public class Promotion
    {
        [Key]
        [Column("prmID")]
        public int? PrmID { get; set; }

        [Column("discountCode")]
        public string? DiscountCode { get; set; }

        [Column("discountAmount")]
        public decimal? DiscountAmount { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("startDate")]
        public DateTime? StartDate { get; set; }

        [Column("endDate")]
        public DateTime? EndDate { get; set; }

        [Column("ownerID")]
        public string? OwnerID { get; set; }
    }

}
