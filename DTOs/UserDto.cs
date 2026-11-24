namespace User_Management.DTOs
{
    public class UserDto
    {
        public int UId { get; set; }

        public string Username { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Middlename { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public int RoleID { get; set; }
        public string RoleName { get; set; } = "";
        public int UserStatus { get; set; }
    }
}
