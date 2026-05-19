using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Ledana.DTOs
{
    public class ProductUpdateDto
    {
        [Required]
        public string? Name { get; set; } = null!;
        [Required]
        public int? Stock { get; set; }
        [Required]
        public int? CategoryId { get; set; }
    }
}
