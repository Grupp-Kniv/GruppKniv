using System.ComponentModel.DataAnnotations;

namespace GruppKniv.Services.OrdersAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId{ get; set; }
        public int Count { get; set; }
        public Product Product{ get; set; }
        public int ProductId { get; set; }
        public User User  { get; set; }
        public int UserId { get; set; }
    }
}
