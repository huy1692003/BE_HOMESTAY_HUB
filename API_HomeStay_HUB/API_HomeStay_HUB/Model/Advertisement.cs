using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Advertisements")]
    public class Advertisement
    {
        [Key]
        [Column("adID")]
        public int? AdID { get; set; }

        [Column("ownerID")]
        public string? OwnerID { get; set; }

        [Column("adTitle")]
        public string? AdTitle { get; set; }

        [Column("adDescription")]
        public string? AdDescription { get; set; }

        [Column("adPicture")]
        public string? AdPicture { get; set; }

        [Column("urlClick")]
        public string? UrlClick { get; set; }

        [Column("startDate")]
        public DateTime? StartDate { get; set; }

        [Column("endDate")]
        public DateTime? EndDate { get; set; }

        [Column("statusAd")]
        public int? StatusAd { get; set; }

        [Column("totalClick")]
        public int? TotalClick { get; set; }

        [Column("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [Column("updatedDate")]
        public DateTime? UpdatedDate { get; set; }
    }

}
