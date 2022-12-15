using GruppKniv.Services.OrdersAPI.Repository;
using AutoMapper;
using GruppKniv.Services.OrdersAPI.Controllers;
using GruppKniv.Services.OrdersAPI.Models.Dto;
using FakeItEasy;

namespace Order.Tests.Controllers
{
    public class OrderControllerTest
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;

        public OrderControllerTest()
        {
            _orderRepository = A.Fake<IOrderRepository>();
            _mapper = A.Fake<IMapper>();
            _response = A.Fake<ResponseDto>();
        }

        [Fact]
        public void OrderController_GetOrders_ReturnTrue()
        {  
            //Arrange
            var order = A.Fake<List<OrderDto>>();
            var orders = A.Fake<List<OrderDto>>();
            A.CallTo(() => _mapper.Map<List<OrderDto>>(order)).Returns(orders);
            var controller = new OrderController(_orderRepository);
            
            //Act
            var result = controller.GetAllOrders();
            
            //Assert
            Assert.True(_response.IsSuccess);
            Assert.NotNull(result);

        }


        [Fact] 
        public void OrderController_GetOrderById_ReturnTrue()
        {
            //Arrange
            var orderController = new OrderController(_orderRepository);

            //Act
            var result = orderController.GetOrder(6);

            //Assert
            Assert.True(_response.IsSuccess);
            Assert.NotNull(result.Result.Equals(true));
            Assert.InRange(result.Id, 1, 100);
        }


        [Fact]
        public void OrderController_PostOrder_ReturnTrue()
        {
            //Arrange
            var newOrder = A.Fake<OrderDto>();
            A.CallTo(() => _mapper.Map<OrderDto>(newOrder)).Returns(newOrder);
            var controller = new OrderController(_orderRepository);

            //Act
            var result = controller.PlaceOrder(newOrder);

            //Assert
            Assert.True(result.IsCompleted);
            Assert.NotNull(result);
        }

    }
}
    
