using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("ReviewAndRatings")]
    public class ReviewAndRating
    {
        [Key]
        [Column("reviewID")]
        public int? ReviewID { get; set; }

        [Column("homestayID")]
        public int? HomestayID { get; set; }

        [Column("customerID")]
        public string? CustomerID { get; set; }

        [Column("rating")]
        public decimal? Rating { get; set; }

        [Column("comment")]
        public string? Comment { get; set; }

        [Column("createdAt")]
        public DateTime? CreatedAt { get; set; }
    }
}
