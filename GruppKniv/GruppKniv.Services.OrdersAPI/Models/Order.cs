using System.ComponentModel.DataAnnotations;

namespace GruppKniv.Services.OrdersAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId{ get; set; }
        public virtual Product Product{ get; set; }
        public User User  { get; set; }
    }
}
