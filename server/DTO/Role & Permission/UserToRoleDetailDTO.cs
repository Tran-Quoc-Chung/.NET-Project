using System.ComponentModel.DataAnnotations;
using server.Models;

    public class UserToRoleDetailDTO
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }=string.Empty;
        public string RoleName { get; set; }=string.Empty;
        
    }
