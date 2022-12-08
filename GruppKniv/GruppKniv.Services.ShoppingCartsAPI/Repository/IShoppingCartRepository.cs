using GruppKniv.Services.ShoppingCartsAPI.Models.DTO;

namespace GruppKniv.Services.ShoppingCartsAPI.Repository;

public interface IShoppingCartRepository
{
    Task<ShoppingCartDto> GetCartByUserIdAsync(string userId);
    Task<ShoppingCartDto> CreateUpdateCartAsync(ShoppingCartDto cartDto);
    //Task<bool> ClearCartAsync(string userId);

    //Task<bool> RemoveFromCartAsync(int cartId);
}
