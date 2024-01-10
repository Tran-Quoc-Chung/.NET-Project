using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace server.DTO
{
    public class UpdateCustomerDTO
    {
        public int CustomerID { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [MaxLength(20)]
        [MinLength(6)]
        public string UserPassword { get; set; } = string.Empty;
        [Unicode]
        public string Phone { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
    }
}
