namespace server.DTO.User
{
    public class GetUserDTO
    {
        public int UserID { get; set; }
        public string Email { get; set; } = string.Empty;
        public int StatusActive { get; set; }
        
    }
}