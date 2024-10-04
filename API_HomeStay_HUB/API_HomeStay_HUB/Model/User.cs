using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API_HomeStay_HUB.Model
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("userID")]
        public string? UserID { get; set; }

        [Column("username")]
        public string? Username { get; set; }

        [Column("fullName")]
        public string? FullName { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("profilePicture")]
        public string? ProfilePicture { get; set; }

        [Column("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("accountStatus")]
        public int? AccountStatus { get; set; }

        [Column("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [Column("status")]
        public int? Status { get; set; }

        [Column("gender")]
        public int? Gender { get; set; }
        public Customer Customer { get; set; }
        public OwnerStay OwnerStay { get; set; }
        public Administrator Administrator { get; set; }

    }
}
