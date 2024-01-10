using System;
namespace server.Models
{
    public class Permission
    {
        public int PermissionID { get; set; }
        public string PermissionName { get; set; } = string.Empty;
        public string? PermissionDescription { get; set; }= string.Empty;
    }
}