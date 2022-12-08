using GruppKniv.Services.ShoppingCartsAPI.Models.DTO;
using GruppKniv.Services.ShoppingCartsAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GruppKniv.Services.ShoppingCartsAPI.Controllers;
[ApiController]
[Route("api/shoppingCart")]
public class ShoppingCartController : Controller
{
    private readonly IShoppingCartRepository _shoppingCart;
    private readonly ResponseDto _response;

    public ShoppingCartController(IShoppingCartRepository shoppingCart)
    {
        _shoppingCart = shoppingCart;
        _response = new ResponseDto();
    }

    [HttpGet("GetShoppingCart/{userId}")]
    public async Task<ResponseDto> GetShoppingCart(string userId)
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
}
