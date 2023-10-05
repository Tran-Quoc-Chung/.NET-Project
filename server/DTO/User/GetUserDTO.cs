using server.Models;

    public class GetUserDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone  { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? RoleID { get; set; } 
        
    }
