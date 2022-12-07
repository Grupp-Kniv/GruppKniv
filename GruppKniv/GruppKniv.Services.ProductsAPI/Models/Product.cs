using System.ComponentModel.DataAnnotations;

namespace GruppKniv.Services.ProductsAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Ingridients { get; set; }
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
        
    }
}
