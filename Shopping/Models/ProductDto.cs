using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public class ProductDto
    {
        [Required,MaxLength(100)]
        public string? ProductName { get; set; }
        [Required,MaxLength(100)]
        public string? ProductBrand { get; set; }
        [Required ,MaxLength(100)]
        public string? ProductCategory { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [ Required,MaxLength(200)]
        public string? ProductDescription { get; set; }
    }
}
