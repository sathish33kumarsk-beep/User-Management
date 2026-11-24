using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Management.Models
{
    [Table("Tbl_Roletypes")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        [MaxLength(200)]
        public string RoleName { get; set; } = "";

        public int Active {  get; set; }

        public ICollection<User> Users { get; set; }
            = new List<User>();
    }
}
