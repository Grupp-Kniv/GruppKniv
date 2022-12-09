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
           
            //Act
            
            //Assert
          
        }
    }
}
    
