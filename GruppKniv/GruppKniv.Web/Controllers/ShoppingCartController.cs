using GruppKniv.Web.Models;
using GruppKniv.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GruppKniv.Web.Controllers;
public class ShoppingCartController : Controller
{
    private readonly IProductService _productService;
    private readonly IShoppingCartService _shoppingCartService;

    //dependency injection
    public ShoppingCartController(IProductService productService, IShoppingCartService shoppingCartService)
    {
        _productService = productService;
        _shoppingCartService = shoppingCartService;
    }
    public async Task<IActionResult> ShoppingCartIndex()
    {
        return View(await LoadCartDtoBasedOnLoggedInUser());
    }

    public async Task<IActionResult> Remove(int cartDetailsId)
    {
        var userId = "string";
        var response = await _shoppingCartService.RemoveFromCartAsync<ResponseDto>(cartDetailsId);


        if (response != null && response.IsSuccess)
        {
            return RedirectToAction(nameof(ShoppingCartIndex));
        }
        return View();
    }

    private async Task<ShoppingCartDto> LoadCartDtoBasedOnLoggedInUser()
    {
        var userId = "string";

        var response = await _shoppingCartService.GetCartByUserIdAsnyc<ResponseDto>(userId);

        ShoppingCartDto cartDto = new();
        if (response != null && response.IsSuccess)
        {
            cartDto = JsonConvert.DeserializeObject<ShoppingCartDto>(Convert.ToString(response.Result));
        }

        if (cartDto.CartHeader != null)
        {
            foreach (var detail in cartDto.CartDetails)
            {
                cartDto.CartHeader.OrderTotal += (detail.Product.Price * detail.Count);
            }
        }
        return cartDto;
    }
}
