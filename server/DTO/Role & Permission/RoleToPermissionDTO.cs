using System.ComponentModel.DataAnnotations;
using server.Models;

public class RoleToPermissionDTO
{
    [Required]
    public int RoleID { get; set; }
    [Required]
    public List<int> PermissionID { get; set; }

}
