using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Amenities")]
    public class Amenities
    {
        [Key]
        [Column("amenityID")]
        public int? AmenityID { get; set; }

        [Column("name")]
        public string? Name { get; set; }

       
    }

}
