using server.Models;
namespace server.DTO.Roles{
    public class UpdateRoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string RoleDescription { get; set; } = string.Empty;
        
    }
}
    
