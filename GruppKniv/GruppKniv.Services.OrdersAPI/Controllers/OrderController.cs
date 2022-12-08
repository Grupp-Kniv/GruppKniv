﻿using GruppKniv.Services.OrdersAPI.Models.Dto;
using GruppKniv.Services.OrdersAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GruppKniv.Services.OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;
        private readonly ResponseDto _response;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _response = new ResponseDto();
        }

        [HttpGet("/orders")]
        public async Task<ResponseDto> GetAllOrders()
        {
            try
            {
                List<OrderDto> orderDto = await _orderRepository.GetAllOrders();
                _response.Result = orderDto;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }


        [HttpGet("/order/{id}")]
        public async Task<ResponseDto> GetOrder(int id)
        {
            try
            {
                OrderDto orderDto = await _orderRepository.GetOrder(id);
                _response.Result = orderDto;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }

    }
}
