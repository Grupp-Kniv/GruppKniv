using GruppKniv.Web.Models;
using GruppKniv.Web.Services.IServices;

namespace GruppKniv.Web.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IHttpClientFactory _clientFactory;

        public OrderService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> GetAllOrdersAsync<T>()
        {

            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/orders",
                AccessToken = ""
            });
        }

        public  async Task<T> GetOrder<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/order/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> PlaceOrder<T>(OrderDto newOrder)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = newOrder,
                Url = StaticDetails.ProductAPIBase + "/api/order/",
                AccessToken = ""
            });
        }
    }
}
