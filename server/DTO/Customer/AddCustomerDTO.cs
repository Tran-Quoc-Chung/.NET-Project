using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace server.DTO
{
    public class AddCustomerDTO
    {
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; }
    }
}
