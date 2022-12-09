using System.ComponentModel.DataAnnotations;

namespace GruppKniv.Services.OrdersAPI.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
    }
}
