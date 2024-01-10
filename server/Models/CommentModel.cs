using System;
using System.ComponentModel.DataAnnotations;
namespace server.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public List<Images>? Image { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        
    }
}
