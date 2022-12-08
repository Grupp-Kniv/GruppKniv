using GruppKniv.Web.Models;

namespace GruppKniv.Web.Services.IServices;

public interface IShoppingCartService
{
    Task<T> GetCartByUserIdAsnyc<T>(string userId, string token = null);
    Task<T> AddToCartAsync<T>(ShoppingCartDto cartDto, string token = null);
    Task<T> UpdateCartAsync<T>(ShoppingCartDto cartDto, string token = null);

    //Task<T> RemoveFromCartAsync<T>(int CartId, string token = null);
}
