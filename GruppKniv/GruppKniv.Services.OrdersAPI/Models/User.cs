using System.ComponentModel.DataAnnotations;

namespace GruppKniv.Services.OrdersAPI.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
    }
}
