using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Ledana.DTOs
{
    public class ProductDto
    {
        [Required]
        public string? Name { get; set; } = null!;
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? Stock { get; set; }
        [Required]
        public int? CategoryId { get; set; }
    }
}
