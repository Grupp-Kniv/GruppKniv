using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppKniv.Services.OrdersAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public virtual string UserName { get; set; }
    }
}
