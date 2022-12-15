using AutoMapper;
using GruppKniv.Services.OrdersAPI.DataAccess;
using GruppKniv.Services.OrdersAPI.Models;
using GruppKniv.Services.OrdersAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace GruppKniv.Services.OrdersAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public OrderRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            List<Order> orders = await _db.Orders.ToListAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            Order order = await _db.Orders.Where(o => o.OrderId == id).Include(p => p.Product).FirstOrDefaultAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> PlaceOrder(OrderDto newOrder)
        {
             Order order = _mapper.Map<OrderDto, Order>(newOrder);
             _db.Orders.Add(order);
             await _db.SaveChangesAsync();
             return _mapper.Map<Order, OrderDto>(order);
        }
    }
}
