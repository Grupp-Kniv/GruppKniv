namespace GruppKniv.Services.OrdersAPI.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public User User { get; set; }

    }
}
