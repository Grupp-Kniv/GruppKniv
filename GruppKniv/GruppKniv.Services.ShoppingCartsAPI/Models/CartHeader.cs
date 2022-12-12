using System.ComponentModel.DataAnnotations;

namespace GruppKniv.Services.ShoppingCartsAPI.Models;
public class CartHeader
{
    [Key]
    public int CartHeaderId { get; set; }
    public string UserId { get; set; }
}
