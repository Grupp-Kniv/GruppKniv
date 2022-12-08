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

    public async Task<T> AddToCartAsync<T>(ShoppingCartDto cartDto, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticDetails.ApiType.POST,
            Data = cartDto,
            Url = StaticDetails.ShoppingCartAPIBase + "/api/shoppingCart/AddShoppingCart",
            AccessToken = ""
        });
    }

    public async Task<T> GetCartByUserIdAsnyc<T>(string userId, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticDetails.ApiType.GET,
            Url = StaticDetails.ShoppingCartAPIBase + "/api/shoppingCart/GetShoppingCart/" + userId,
            AccessToken = ""
        });
    }

    public async Task<T> UpdateCartAsync<T>(ShoppingCartDto cartDto, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = StaticDetails.ApiType.PUT,
            Data = cartDto,
            Url = StaticDetails.ShoppingCartAPIBase + "/api/shoppingCart/UpdateShoppingCart",
            AccessToken = ""
        });
    }
}
