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
    private async Task<List<ShoppingCartDto>> LoadCartDtoBasedOnLoggedInUser()
    {
        var userId = "string";

        var response = await _shoppingCartService.GetCartByUserIdAsnyc<ResponseDto>(userId);

        List<ShoppingCartDto> cartDto = new();
        if (response != null && response.IsSuccess)
        {
            cartDto = JsonConvert.DeserializeObject<List<ShoppingCartDto>>(Convert.ToString(response.Result));
        }

        if (cartDto != null)
        {
            foreach (var detail in cartDto)
            {
                detail.TotalCart += (detail.Product.Price * detail.Count);
            }
        }
        return cartDto;
    }
}
