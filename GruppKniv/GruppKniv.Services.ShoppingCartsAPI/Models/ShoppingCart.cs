namespace GruppKniv.Services.ShoppingCartsAPI.Models;

public class ShoppingCart
{
    public CartHeader CartHeader { get; set; }
    public IEnumerable<CartDetails> CartDetails { get; set; }

}
