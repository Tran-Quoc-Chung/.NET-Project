using server.Models;

public class GetUserDTO
{
    public int UserID { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int Status { get; set; }
    public int? RoleID { get; set; }
    public string Displayname { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int GenderID { get; set; }
    public List<int>? ListPermission { get; set; } 



}
