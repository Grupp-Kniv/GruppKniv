using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppKniv.Services.OrdersAPI.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId{ get; set; }
        public virtual Product Product{ get; set; }

       public User User  { get; set; }

    }
}
