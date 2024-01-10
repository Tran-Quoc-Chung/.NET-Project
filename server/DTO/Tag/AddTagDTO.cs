using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO.Tag
{
    public class AddTagDTO
    {
        public int TagID { get; set; }
        [Required]
        public string TagName { get; set; } = string.Empty;    
        }
}
