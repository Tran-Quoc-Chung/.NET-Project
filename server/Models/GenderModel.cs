using System;
using System.ComponentModel.DataAnnotations;
namespace server.Models
{
    public class Gender
    {
        public int GenderID { get; set; }
        public string GenderName { get; set; } = string.Empty;
    }
}
