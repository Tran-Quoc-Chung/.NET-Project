using server.Models;
namespace server.DTO.Roles{
    public class GetRoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string RoleDescription { get; set; } = string.Empty;
        
    }
}
    
