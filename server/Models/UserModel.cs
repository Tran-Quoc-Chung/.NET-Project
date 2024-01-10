using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
namespace server.Models
{
    public class User
    {

        public int UserID { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        [Required]
        public Gender Gender { get; set; } = null!;
        public SystemStatus Status { get; set; }= null!;
    }
}
