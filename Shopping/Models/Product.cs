using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? ProductName { get; set; }
        [MaxLength (100)]
        public string? ProductBrand { get; set; }
        [MaxLength(100)]
        public string? ProductCategory { get; set; }
        [Precision(16,2)]
        public int ProductPrice { get; set; }
        [MaxLength(200)]
        public string? ProductDescription { get; set; } 
    }
}
