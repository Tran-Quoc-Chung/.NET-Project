using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace server.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        [Unicode]
        public string UserName { get; set; }= string.Empty;
        [MaxLength(20)]
        [MinLength(6)]
        public string UserPassword { get; set; }= string.Empty;
        [Unicode]
        public string Phone { get; set; }= string.Empty;
        public DateTime Birthday { get; set; }
    }
}
