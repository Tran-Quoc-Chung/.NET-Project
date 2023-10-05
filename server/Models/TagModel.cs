using System;
using System.ComponentModel.DataAnnotations;
namespace server.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        [Required]
        public string TagName { get; set; } = string.Empty;    
        }
}
