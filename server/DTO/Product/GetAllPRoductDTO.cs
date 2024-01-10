using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class GetAllProductDTO{
        public int ProductID {get; set; }

        public string ProductName {get; set;} = string.Empty;
        public float Price {get; set; }

        public string TagName { get; set; } = string.Empty;

        public string GenderName {get; set;}= string.Empty;
        public string CreatedAt {get; set;}= string.Empty;
        public string CreatedBy {get; set;}= string.Empty;
        public string? Images { get; set; } = string.Empty;
        public int? TotalRemain { get; set; }

    }
}