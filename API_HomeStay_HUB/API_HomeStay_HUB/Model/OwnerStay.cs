using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("OwnerStays")]
    public class OwnerStay
    {
        [Key]
        [Column("ownerID")]
        public string? OwnerID { get; set; }

        [Column("userID")]
        public string? UserID { get; set; }

        [Column("bannerImage")]
        public string? BannerImage { get; set; }

        [Column("defaultCheckinTime")]
        public string? DefaultCheckinTime { get; set; }

        [Column("defaultCheckoutTime")]
        public string? DefaultCheckoutTime { get; set; }

        [Column("description")]
        public string? Description { get; set; }
        public virtual User? User { get; set; } // Mối quan hệ đến User
    }
}
