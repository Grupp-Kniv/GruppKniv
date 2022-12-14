using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppKniv.Services.OrdersAPI.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}
