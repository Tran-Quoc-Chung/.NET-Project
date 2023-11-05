using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace server.DTO
{
    public class GetCustomerDTO
    {
        public int CustomerID { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
      
        public string UserName { get; set; } = string.Empty;
     
        public string UserPassword { get; set; } = string.Empty;
     
        public string Phone { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
    }
}
