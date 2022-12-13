using GruppKniv.Web.Models;
using GruppKniv.Web.Services.IServices;

namespace GruppKniv.Web.Services;

public class ShoppingCartService : BaseService, IShoppingCartService
{
    private readonly IHttpClientFactory _clientFactory;

    public ShoppingCartService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<T> AddToCartAsync<T>(ShoppingCartDto cartDto, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticDetails.ApiType.POST,
            Data = cartDto,
            Url = StaticDetails.ShoppingCartAPIBase + "/api/shoppingCart/AddShoppingCart",
            AccessToken = token
        });
    }

    public async Task<T> GetCartByUserIdAsnyc<T>(string userId, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticDetails.ApiType.GET,
            Url = StaticDetails.ShoppingCartAPIBase + "/api/shoppingCart/GetShoppingCart/" + userId,
            AccessToken = token
        });
    }

    public async Task<T> UpdateCartAsync<T>(ShoppingCartDto cartDto, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticDetails.ApiType.PUT,
            Data = cartDto,
            Url = StaticDetails.ShoppingCartAPIBase + "/api/shoppingCart/UpdateShoppingCart",
            AccessToken = token
        });
    }

    public async Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticDetails.ApiType.POST,
            Data = cartId,
            Url = StaticDetails.ShoppingCartAPIBase + "/api/shoppingCart/RemoveShoppingCart",
            AccessToken = ""
        });
    }
}
