using GruppKniv.Web.Models;

namespace GruppKniv.Web.Services.IServices
{
    public interface IOrderService : IBaseService
    {
        Task<T> GetAllOrdersAsync<T>(string token);
        Task<T> GetOrder<T>(int id, string token);
        Task<T> PlaceOrder<T>(OrderDto newOrder, string token);



    }
}
