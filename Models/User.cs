using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Management.Models
{
    [Table("Tbl_Login_Userdetails")]
    public class User
    {
        [Key]
        public int Uid { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = "";

        [Required]
        [MaxLength(256)]
        public string Password { get; set; } = "";

        [MaxLength(50)]
        public string Firstname { get; set; } = "";

        [MaxLength(50)]
        public string Middlename { get; set; } = "";

        [MaxLength(50)]
        public string Lastname { get; set; } = "";

        [MaxLength(200)]
        public string EmailAddress { get; set; } = "";

        public int RoleID { get; set; }
        public int UserStatus {  get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; } = null!;
    }
}
