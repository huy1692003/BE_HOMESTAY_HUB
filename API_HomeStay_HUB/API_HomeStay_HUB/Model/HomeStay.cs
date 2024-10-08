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

        [Column("addressDetail")]
        public string? AddressDetail { get; set; }

        [Column("conscious")]
        public string? Conscious { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("imagePreview")]
        public string? ImagePreview { get; set; }

        [Column("imageDetail")]
        public string? ImageDetail { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("pricePerNight")]
        public double? PricePerNight { get; set; }

        [Column("amenities")]
        public string? Amenities { get; set; }

        [Column("capacity")]
        public int? Capacity { get; set; }

        [Column("minStayDuration")]
        public int? MinStayDuration { get; set; }

        [Column("rentalCount")]
        public int? RentalCount { get; set; }

        [Column("approvalStatus")]
        public int? ApprovalStatus { get; set; }

        [Column("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [Column("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [Column("numberOfBedrooms")]
        public int? NumberOfBedrooms { get; set; }

        [Column("numberOfLivingRooms")]
        public int? NumberOfLivingRooms { get; set; }

        [Column("numberOfBathrooms")]
        public int? NumberOfBathrooms { get; set; }

        [Column("isLocked")]
        public int? IsLocked { get; set; }
    }
}
