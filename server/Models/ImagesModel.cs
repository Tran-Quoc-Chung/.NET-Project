using System;
namespace server.Models
{
    public class Images
    {
        public int ImagesID { get; set; }
        public string ImagesUrl { get; set; } = string.Empty;
        public string? ImagesDesc { get; set; } = string.Empty;
        public string ImagesType { get; set; }
        public Product Product { get; set; }

    }
}
