using System.ComponentModel.DataAnnotations;

namespace User_Management.DTOs
{
    public class UpdateUserDto
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = "";
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; } = "";
        
        [MaxLength(50)]
        public string Middlename { get; set; } = "";

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; } = "";

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string EmailAddress { get; set; } = "";

        [Range(1, int.MaxValue)]
        public int RoleID { get; set;  }
        [Range(0,1)]
        public int UserStatus { get; set; }


    }
}
