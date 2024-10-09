using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Favorites")]
    public class Favorites
    {
        [Key]
        [Column("favID")]
        public int FavID { get; set; }

        [Column("cusID")]
        public string? CusID { get; set; }

        [Column("homestayID")]
        public int? HomestayID { get; set; }

        [Column("createdAt")]
        public DateTime? CreatedAt { get; set; }

      
    }

}
