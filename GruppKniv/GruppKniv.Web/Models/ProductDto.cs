using System.ComponentModel.DataAnnotations;

namespace GruppKniv.Web.Models
{
    public class ProductDto
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(1, 10000)]
        public double Price { get; set; }

        public string? Ingridients { get; set; }
        public string? ImageUrl { get; set; }
    }
}
