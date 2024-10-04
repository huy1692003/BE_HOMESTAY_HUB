using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Administrators")]
    public class Administrator
    {
        [Key]
        [Column("adminID")]
        public string? AdminID { get; set; }

        [Column("userID")]
        public string? UserID { get; set; }

        [Column("roleID")]
        public string? RoleID { get; set; }
        public  User? User { get; set; } // Mối quan hệ đến User
    }
}
