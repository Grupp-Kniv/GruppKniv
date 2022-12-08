using AutoMapper;
using FakeItEasy;
using GruppKniv.Services.ShoppingCartsAPI.Controllers;
using GruppKniv.Services.ShoppingCartsAPI.Models.DTO;
using GruppKniv.Services.ShoppingCartsAPI.Repository;

namespace ShoppingCart.Tests.Controller;
public class ShoppingCartControllerTest
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly ResponseDto _response;
    private readonly IMapper _mapper;

    public ShoppingCartControllerTest()
    {
        _shoppingCartRepository = A.Fake<IShoppingCartRepository>();
        _mapper = A.Fake<IMapper>();
        _response = A.Fake<ResponseDto>();
    }


    [Fact]
    public void ShoppingCartController_GetShoppingCartByUserId_Returntrue()
    {
        //Arrange
        var shoppingCart = A.Fake<ShoppingCartDto>();
        var userId = "string";
        A.CallTo(() => _mapper.Map<ShoppingCartDto>(shoppingCart)).Returns(shoppingCart);
        var controller = new ShoppingCartAPIController(_shoppingCartRepository);

        //Act
        var result = controller.GetShoppingCartByUserId(userId);

        //Assert
        Assert.True(result.IsCompleted);
        Assert.NotNull(result);
    }

    [Fact]
    public void ShoppingCartController_AddShoppingCart_Returntrue()
    {
        //Arrange
        var shoppingCart = A.Fake<ShoppingCartDto>();
        A.CallTo(() => _mapper.Map<ShoppingCartDto>(shoppingCart)).Returns(shoppingCart);
        var controller = new ShoppingCartAPIController(_shoppingCartRepository);

        //Act
        var result = controller.AddShoppingCart(shoppingCart);

        //Assert
        Assert.True(result.IsCompleted);
        Assert.NotNull(result);
    }

    [Fact]
    public void ShoppingCartController_UpdateShoppingCart_Returntrue()
    {
        //Arrange
        var shoppingCart = A.Fake<ShoppingCartDto>();
        A.CallTo(() => _mapper.Map<ShoppingCartDto>(shoppingCart)).Returns(shoppingCart);
        var controller = new ShoppingCartAPIController(_shoppingCartRepository);

        //Act
        var result = controller.UpdateShoppingCart(shoppingCart);

        //Assert
        Assert.True(result.IsCompleted);
        Assert.NotNull(result);
    }
}
