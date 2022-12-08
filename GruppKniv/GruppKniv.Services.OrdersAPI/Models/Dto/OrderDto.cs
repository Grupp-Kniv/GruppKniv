namespace GruppKniv.Services.OrdersAPI.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int Count { get; set; }
        public ProductDto Product { get; set; }
        public int ProductId { get; set; }
        public UserDto User { get; set; }
        public int UserId { get; set; }

    }
}
