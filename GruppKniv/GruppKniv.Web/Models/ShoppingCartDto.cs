namespace GruppKniv.Web.Models;

public class ShoppingCartDto
{
    public int ShoppingCartId { get; set; }
    public string UserId { get; set; }
    public virtual ProductDto Product { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public double TotalCart { get; set; }
}
