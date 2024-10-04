using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("HomeStays")]
    public class HomeStay
    {
        [Key]
        [Column("homestayID")]
        public int? HomestayID { get; set; }

        [Column("ownerID")]
        public string? OwnerID { get; set; }

        [Column("location")]
        public string? Location { get; set; }

        [Column("price")]
        public decimal? Price { get; set; }

        [Column("totalRooms")]
        public int? TotalRooms { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("picturePreview")]
        public string? PicturePreview { get; set; }

        [Column("rating")]
        public decimal? Rating { get; set; }

        [Column("totalReviews")]
        public int? TotalReviews { get; set; }
    }

}
