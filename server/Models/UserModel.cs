using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
namespace server.Models
{
    public class User
    {

        public int UserID { get; set; }
        [Unicode]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string UserPassword { get; set; } = string.Empty;
        [AllowNull]
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [Required]
        public StatusActive Status { get; set; }
        //displayname

    }
}
