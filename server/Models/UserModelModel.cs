using System;
namespace server.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }= string.Empty;
        public string UserPassword { get; set; }= string.Empty;
        public int StatusActive { get; set; }
        public string Phone { get; set; }= string.Empty;
        public StatusActive Status { get; set; }
    }
}
