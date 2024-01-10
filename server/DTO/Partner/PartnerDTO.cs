using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace server.DTO
{
    public class PartnerDTO
    {
        public int PartnerID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string Birthday { get; set; } = string.Empty;
    }
}
