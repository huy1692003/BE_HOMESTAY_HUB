using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HomeStay_HUB.Model
{
    [Table("HomeStays")]
    public class HomeStay
    {
        [Key]
        [Column("homestayID")]
        public int? HomestayID { get; set; }

        [Column("homestayName")]
        public string? HomestayName { get; set; }

        [Column("ownerID")]
        public string? OwnerID { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("province")]  // Thêm trường tỉnh thành
        public string? Province { get; set; }

        [Column("conscious")]
        public string? Conscious { get; set; }

        [Column("addressDetail")]
        public string? AddressDetail { get; set; }

        [Column("imagePreview")]
        public string? ImagePreview { get; set; }

        [Column("pricePerNight")]
        public double? PricePerNight { get; set; }

        [Column("discountSecondNight")]  // Trường mới cho giảm giá từ đêm thứ 2
        public double? DiscountSecondNight { get; set; }      

        [Column("minPerson")]
        public int? MinPerson { get; set; }

        [Column("maxPerson")]
        public int? MaxPerson { get; set; }

        [Column("isLocked")]
        public int? IsLocked { get; set; }

        [Column("approvalStatus")]
        public int? ApprovalStatus { get; set; }

        [Column("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [Column("updatedAt")]
        public DateTime? UpdatedAt { get; set; }


    }
}
