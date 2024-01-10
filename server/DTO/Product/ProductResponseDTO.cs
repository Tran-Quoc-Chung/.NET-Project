using System;
using System.ComponentModel.DataAnnotations;
using server.Models;
namespace server.DTO
{
    public class ProductResponseDTO{
        public GetProductDTO Product { get; set; } = null!;
        public List<Images>? ProductImage { get; set; }= null!;
    }
    

}