using AutoMapper;
using GruppKniv.Services.OrdersAPI.DataAccess;
using GruppKniv.Services.OrdersAPI.Models;
using GruppKniv.Services.OrdersAPI.Models.Dto;
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

        public async Task<List<OrderDto>> GetAllOrders()
        {
            List<Order> orders = await _db.Orders.ToListAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            Order order = await _db.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();

            return _mapper.Map<OrderDto>(order);
        }

        /*public Task<bool> PlaceOrder(ShoppingCart cart)
        {
            throw new NotImplementedException();
        }*/
    }
}
