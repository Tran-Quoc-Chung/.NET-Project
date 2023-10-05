using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class AddUserDTO
    {
        [Required]
        public string UserName { get; set; }= string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string UserPassword { get; set; }= string.Empty;
        [Required]
        public int StatusActive { get; set; }
        [Required]
        public string Phone { get; set; }= string.Empty;
    }
}
