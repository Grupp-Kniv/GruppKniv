using System.ComponentModel.DataAnnotations;

namespace GruppKniv.Services.ShoppingCartsAPI.Models;

public class ShoppingCart
{
    [Key]
    public int ShoppingCartId { get; set; }
    public string UserId { get; set; }
    public virtual Product Product { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }

}
