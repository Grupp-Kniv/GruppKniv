using GruppKniv.Web.Models;

namespace GruppKniv.Web.Services.IServices
{
    public interface IOrderService : IBaseService
    {
        Task<T> GetAllOrdersAsync<T>();
        Task<T> GetOrder<T>(int id);
        Task<T> PlaceOrder<T>(OrderDto newOrder);



    }
}
