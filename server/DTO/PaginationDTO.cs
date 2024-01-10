using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class PaginationDTO
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public int? Gender { get; set; }
        public int? Sort { get; set; } 
        public int? Price { get; set; }
        public int? Brand { get; set; }
        public int? StrapMaterial { get; set; }
        

    }
}
