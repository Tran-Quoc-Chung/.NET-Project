using System.ComponentModel.DataAnnotations;
using server.Models;

    public class RoleToPermissionDetailDTO
    {

    public string RoleName { get; set; }
    public List<string> PermissionName { get; set; }
    public List<int>? PermissionID { get; set; }
        
    }
