using GruppKniv.Services.ShoppingCartsAPI.Models.DTO;
using GruppKniv.Services.ShoppingCartsAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GruppKniv.Services.ShoppingCartsAPI.Controllers;
[ApiController]
[Route("api/shoppingCart")]
public class ShoppingCartAPIController : Controller
{
    private readonly IShoppingCartRepository _shoppingCart;
    private readonly ResponseDto _response;

    public ShoppingCartAPIController(IShoppingCartRepository shoppingCart)
    {
        _shoppingCart = shoppingCart;
        _response = new ResponseDto();
    }

    [Authorize]
    [HttpGet("GetShoppingCart/{userId}")]
    public async Task<ResponseDto> GetShoppingCartByUserId(string userId)
    {
        try
        {
            ShoppingCartDto shoppingCartDto = await _shoppingCart.GetCartByUserIdAsync(userId);
            _response.Result = shoppingCartDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [Authorize]
    [HttpPost("AddShoppingCart")]
    public async Task<ResponseDto> AddShoppingCart(ShoppingCartDto shoppingCartDto)
    {
        try
        {
            ShoppingCartDto shoppingCartDto_1 = await _shoppingCart.CreateUpdateCartAsync(shoppingCartDto);
            _response.Result = shoppingCartDto_1;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [Authorize]
    [HttpPost("UpdateShoppingCart")]
    public async Task<ResponseDto> UpdateShoppingCart(ShoppingCartDto shoppingCartDto)
    {
        try
        {
            ShoppingCartDto shoppingCartDto_1 = await _shoppingCart.CreateUpdateCartAsync(shoppingCartDto);
            _response.Result = shoppingCartDto_1;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [Authorize]
    [HttpPost("RemoveShoppingCart")]
    public async Task<object> RemoveCart([FromBody] int cartId)
    {
        try
        {
            bool isSuccess = await _shoppingCart.RemoveFromCartAsync(cartId);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }
}
