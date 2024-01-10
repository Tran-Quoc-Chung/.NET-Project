namespace server.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string? RoleDescription { get; set; } = string.Empty;
        public User CreatedBy { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}