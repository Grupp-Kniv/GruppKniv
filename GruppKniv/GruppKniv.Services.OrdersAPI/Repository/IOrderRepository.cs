﻿using GruppKniv.Services.OrdersAPI.Models;
using GruppKniv.Services.OrdersAPI.Models.Dto;

namespace GruppKniv.Services.OrdersAPI.Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderDto>> GetAllOrders();
        Task<OrderDto> GetOrder(int id);
        Task<OrderDto> PlaceOrder(Order mewOrder);
    }
}
