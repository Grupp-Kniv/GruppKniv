using GruppKniv.Services.OrdersAPI.Models.Dto;

namespace GruppKniv.Web.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public virtual ProductDto Product { get; set; }
        public UserDto User { get; set; }

    }
}

