using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class ProductClientDTO{
        public List<GetAllProductDTO> ProductList {get; set;} = new List<GetAllProductDTO>();
        public int? RemainProduct { get; set; }
        public int? Page { get; set; }
    }
}