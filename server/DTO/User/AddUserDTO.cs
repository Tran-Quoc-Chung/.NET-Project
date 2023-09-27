using System;
namespace server.DTO
{
    public class AddUserDTO
    {
        public string Email { get; set; }= string.Empty;
        public string UserPassword { get; set; }= string.Empty;
        public int StatusActive { get; set; }
        public string Phone { get; set; }= string.Empty;
    }
}
