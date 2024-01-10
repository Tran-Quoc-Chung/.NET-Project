using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class AddUserDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string DisplayName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }= string.Empty;
        [Required]
        public int StatusActive { get; set; }
        public string Phone { get; set; }= string.Empty;
        public string Address { get; set; }= string.Empty;
        public int GenderID { get; set; }
    }
}
