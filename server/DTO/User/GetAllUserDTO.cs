using server.Models;

public class GetAllUserDTO
{
    public int UserID { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Displayname { get; set; } = string.Empty;
    public string? RoleName { get; set; } = string.Empty;

}
