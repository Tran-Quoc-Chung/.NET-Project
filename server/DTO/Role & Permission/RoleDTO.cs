using server.Models;

public class RoleDTO
{
    public int RoleID { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string RoleDescription { get; set; } = string.Empty;
    public string? CreatedBy { get; set; }
    public string? CreatedAt { get; set; }


}
