﻿namespace GruppKniv.Services.OrdersAPI.Models.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Ingridients { get; set; }
        public string ImageUrl { get; set; }
    }
}
