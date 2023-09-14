namespace server.Models
{
    public class RoleToPermission
    {
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}