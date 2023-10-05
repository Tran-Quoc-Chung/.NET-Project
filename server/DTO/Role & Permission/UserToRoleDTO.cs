using System.ComponentModel.DataAnnotations;
using server.Models;

    public class UserToRoleDTO
    {
        [Required]
        public int RoleID { get; set; }
        [Required]
        public int UserID { get; set; }
        
    }
